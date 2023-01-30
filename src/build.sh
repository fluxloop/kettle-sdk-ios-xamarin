#!/usr/bin/env bash

msbuild -t:Clean,Build -p:Configuration=Release Kettle.iOS.csproj
nuget pack kettle.nuspec 