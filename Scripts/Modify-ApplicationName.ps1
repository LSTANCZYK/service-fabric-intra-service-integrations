#
# Modifies the Application Name in ApplicationParameters/Cloud.xml to include the version number found in the ApplicationManifest.xml
# Run this script from the root of the project

$manifestFileName = "$pwd\ApplicationPackageRoot\ApplicationManifest.xml"
$cloudFileName = "$pwd\ApplicationParameters\Cloud.xml"

[xml]$manifest = get-content $manifestFileName
[xml]$cloudConfig = get-content $cloudFileName

$cloudConfig.Application.Name = $cloudConfig.Application.Name + '-' + $manifest.ApplicationManifest.ApplicationTypeVersion
$cloudConfig.Save($cloudFileName)

