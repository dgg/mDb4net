db.PostalCodes.update({}, {$unset : {'field3' : 0, 'field4' : 0, 'field5' : 0, 'field6' : 0, 'field7' : 0, 'field8' : 0, 'field11' : 0}}, { multi: true });
db.PostalCodes.update({}, {$rename : {'field9' : 'latitude', 'field10' : 'longitude'}}, { multi: true });