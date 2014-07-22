$mongo_dir = "d:\Program Files\mongodb\"
$mongo_import = Join-Path $mongo_dir "mongoimport.exe"

&$mongo_import --% -d geoQueries -c PostalCodes -type tsv -fields countryCode,postalCode,placeName -file DK.tsv
&$mongo_import --% -d geoQueries -c PostalCodes -type tsv -fields countryCode,postalCode,placeName -file NO.tsv
&$mongo_import --% -d geoQueries -c PostalCodes -type tsv -fields countryCode,postalCode,placeName -file SE.tsv

$mongo = Join-Path $mongo_dir "mongo.exe"
&$mongo --% geoQueries editFields.js