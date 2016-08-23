$nuget = $env:NuGet

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition
$sourcesPath = (get-item $scriptPath ).parent.FullName
$sourcesPath
# parse the version number out of package.json
$bsversion = ((Get-Content $sourcesPath\package.json) -join "`n" | ConvertFrom-Json).version

# create packages
& $nuget pack "nuget\bootstrap.nuspec" -Verbosity detailed -NonInteractive -NoPackageAnalysis -BasePath $sourcesPath -Version $bsversion
& $nuget pack "nuget\bootstrap.less.nuspec" -Verbosity detailed -NonInteractive -NoPackageAnalysis -BasePath $sourcesPath -Version $bsversion
