#r "paket: 
nuget FSharp.Core
nuget Fake.Core.Target
nuget Fake.IO.FileSystem
nuget Fake.DotNet.Cli
nuget Fake.Tools.Git
nuget Fake.DotNet.Paket
nuget Fake.DotNet.Testing.NUnit
nuget Fake.BuildServer.TeamCity
nuget Fake.Core.CommandLineParsing
"
#load "./.fake/build.fsx/intellisense.fsx"

//Temporary fix until this is resolved : https://github.com/mono/mono/issues/9315
#if !FAKE
#r "Facades/netstandard"
#r "netstandard"
#endif
//Temporary fix until this is resolved : https://github.com/mono/mono/issues/9315

open System
open Microsoft.FSharp.Collections
open Fake.BuildServer
open Fake.Core
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.Tools

BuildServer.install [
    TeamCity.Installer
]

let (|?) a b = match b with Some x -> Some x | None -> a
let (|!) opt defaultValue = defaultArg opt defaultValue

let cli= """
Usage:
  build.cmd [--target=<target>] [--configuration=<cfg>] [--package=<package>...] [--tag=<tag>]
  build.cmd -h --help

Options:
  -h --help              Show this screen.
  --package=<package>    Name of the package to build
  --configuration=<cfg>  Build configuration [default: debug]
  --tag:                 in Release configuration       : defaults to branchname if not master
                         in other (Debug) configuration : defaults no official
 """

let ctx = Context.forceFakeContext ()
let args = ctx.Arguments

// Keep supporting arguments without '--'
let argsDashed = 
    args 
    |> List.map(fun arg -> 
        if (String.startsWith "--" arg) then arg else "--" + arg)

let parser = Docopt(cli)
let parsedArguments = parser.Parse(argsDashed |> List.toArray)

let getBuildParamOrNone name =
    DocoptResult.tryGetArgument name parsedArguments
let rootDir = __SOURCE_DIRECTORY__
let configuration = getBuildParamOrNone "--configuration" |! "Debug"

let srcDir = rootDir 
let slnFile = rootDir |> Directory.findFirstMatchingFile "*.sln"
Trace.tracefn "Configuration: '%s'" configuration

Target.create "Build" (fun _ ->
    DotNet.build (fun ps -> { 
        ps with 
            Configuration = DotNet.BuildConfiguration.fromString configuration 
            }) slnFile
)

Target.create "Pack" (fun _ ->    
    let tag : string option = 
        let getTagFromBranch  () =
            Environment.environVarOrNone "BUILD_BRANCH"
            |? (Git.Information.getBranchName rootDir |> Some)
            |> Option.filter (fun s -> s.TrimEnd().EndsWith("master") |> not)
            |> Option.filter(fun _ -> configuration = "Release")

        let sanitizeAsNuGetLabel (s:string) =
            let partAfterSlash = if s.Contains("/") then (s |> Seq.skipWhile (fun c -> c <> '/') |> Seq.skip 1 |> String.Concat) else s

            let isValidChar c = (String.isLetterOrDigit c) || (c = '-')

            partAfterSlash + " " // add invalid char to end to prevent pairwise from skipping last char
                |> Seq.map (fun c -> if (isValidChar c) then c else '-') // replace invalid chars with '-'     
                |> Seq.pairwise                                          // pair consecutive characters, and
                |> Seq.filter (fun x -> match x with                     // remove multiple consecutile dashes
                                        | ('-', '-') -> false
                                        | _ -> true )
                |> Seq.map (fun (l, _) -> l)                             // unpair
                |> Seq.skipWhile (fun c -> Char.IsNumber(c) || c = '-')  // skip till we find a letter; label should not start with a number or dash
                |> Seq.truncate 20                                       // nuget only allows a 20 char max for prerelease part of version
                |> String.Concat
                |> String.toLower

        getBuildParamOrNone "--tag"
        |? getTagFromBranch ()
        |> Option.map sanitizeAsNuGetLabel
        |> Option.filter(fun s -> s <> "")

    Trace.tracefn "Tag: '%s'" (tag |! "(none)")
    
    let outputPath = rootDir @@ "nugets"
    Directory.delete outputPath
    Directory.ensure outputPath
    
    let packages = 
        getBuildParamOrNone "--package"
        |> Option.map(fun p -> p.Split(','))
        |> Option.map Seq.toList
        |! (
            srcDir 
            |> DirectoryInfo.ofPath
            |> DirectoryInfo.getSubDirectories
            |> Seq.map(fun d -> d.Name)
            |> Seq.filter (fun s -> s.Contains(".Test") |> not)
            |> Seq.toList
        )

    let createPackOptions (ps: DotNet.PackOptions) = 
        { ps with
            Configuration = DotNet.BuildConfiguration.fromString configuration
            VersionSuffix = tag
            OutputPath = Some outputPath
            NoBuild = true }

    packages 
    |> Seq.iter (fun package -> 
        Trace.tracefn "Package: '%s'" package
        DotNet.pack createPackOptions (srcDir @@ package @@ (package + ".csproj"))
        )
)

Target.create "Test" <| fun _ ->
    DotNet.test (fun p -> { p with Configuration = DotNet.BuildConfiguration.fromString configuration }) slnFile

// Dependencies
"Build"
    ==> "Test"
    ==> "Pack"

let target =
    parsedArguments
    |> DocoptResult.tryGetArgument "--target"  
    |! "Build"

Target.run 1 target []