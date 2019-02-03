dotnet clean
dotnet restore
dotnet build --output "$((Get-Item -Path ".\").FullName)\bin\Debug\win7-x64" --configuration Debug --runtime win7-x64 --verbosity diag
dotnet build --output "$((Get-Item -Path ".\").FullName)\bin\Release\win7-x64" --configuration Release --runtime win7-x64 --verbosity diag
