$mongo_dir = "d:\Program Files\mongodb\"
$mongo_import = Join-Path $mongo_dir "mongoimport.exe"

&$mongo_import --% -d pitfalls -c PostalCodes -type tsv -fields countryCode,postalCode,placeName -file DK.tsv

$mongo = Join-Path $mongo_dir "mongo.exe"
&$mongo --% pitfalls editFields.js