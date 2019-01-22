// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using YamlDotNet.RepresentationModel;

namespace AutoRest.Swagger.Logging
{
    /// <summary>
    ///     Represents a path into an object.
    /// </summary>
    public class ObjectPath
    {
        private ObjectPath(IEnumerable<ObjectPathPart> path)
        {
            Path = path;
        }

        public static ObjectPath Empty => new ObjectPath(Enumerable.Empty<ObjectPathPart>());

        public IEnumerable<ObjectPathPart> Path { get; }

        // https://tools.ietf.org/html/draft-ietf-appsawg-json-pointer-04
        public string JsonPointer => string.Concat(Path.Select(p => p.JsonPointer));

        // http://goessner.net/articles/JsonPath/, https://github.com/jayway/JsonPath
        public string JsonPath => "$" + string.Concat(Path.Select(p => p.JsonPath));

        public string ReadablePath => string.Concat(Path.Select(p => p.ReadablePath));

        private ObjectPath Append(ObjectPathPart part)
        {
            return new ObjectPath(Path.Concat(new[] {part}));
        }

        public ObjectPath AppendIndex(int index)
        {
            return Append(new ObjectPathPartIndex(index));
        }

        public ObjectPath AppendProperty(string property)
        {
            return Append(new ObjectPathPartProperty(property));
        }

        public YamlNode SelectNode(YamlNode node)
        {
            var result = node;
            foreach (var part in Path) result = part.SelectNode(ref node) ?? result;
            return result;
        }
    }
}