$mongo_dir = "d:\Program Files\mongodb\"
$mongo_import = Join-Path $mongo_dir "mongoimport.exe"
&$mongo_import --% -d aggregation -c Grades -file Grades.json