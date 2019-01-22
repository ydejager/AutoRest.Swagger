@ECHO OFF
SET BUILD_PACKAGES=.fake
SET FAKE_CLI="%BUILD_PACKAGES%/fake.exe"

IF NOT EXIST %FAKE_CLI% (
  dotnet tool install fake-cli --tool-path ./%BUILD_PACKAGES%
)

%FAKE_CLI% -v run build.fsx -- %*