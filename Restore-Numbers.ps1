$mongo_dir = "d:\Program Files\mongodb\"
$mongo_restore = Join-Path $mongo_dir "mongorestore.exe"
&$mongo_restore --% -d basics -c FunnyNumbers .\data\funnynumbers.bson