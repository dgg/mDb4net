$mongo_dir = "d:\Program Files\mongodb\"
$mongo_import = Join-Path $mongo_dir "mongoimport.exe"

&$mongo_import --% -d indexing -c PostalCodes -type tsv -fields countryCode,postalCode,placeName -file DK.tsv
&$mongo_import --% -d indexing -c PostalCodes -type tsv -fields countryCode,postalCode,placeName -file NO.tsv
&$mongo_import --% -d indexing -c PostalCodes -type tsv -fields countryCode,postalCode,placeName -file SE.tsv

$mongo = Join-Path $mongo_dir "mongo.exe"
&$mongo --% indexing editFields.js