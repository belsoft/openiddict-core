$nuget = $env:NuGet

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition

$env:SourcesPath = (get-item $scriptPath ).parent.FullName

$env:SourcesPath

# parse the version number out of package.json
$bsversion = ((Get-Content $env:SourcesPath\package.json) -join "`n" | ConvertFrom-Json).version

# create packages
& $nuget pack $env:SourcesPath + "nuget\bootstrap.nuspec" -Verbosity detailed -NonInteractive -NoPackageAnalysis -BasePath $env:SourcesPath -Version $bsversion
& $nuget pack $env:SourcesPath + "nuget\bootstrap.less.nuspec" -Verbosity detailed -NonInteractive -NoPackageAnalysis -BasePath $env:SourcesPath -Version $bsversion
