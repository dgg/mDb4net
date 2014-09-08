$mongo_dir = "d:\Program Files\mongodb\"
$mongo_import = Join-Path $mongo_dir "mongoimport.exe"

&$mongo_import --% -d basics -c Posts -file .\data\posts.json