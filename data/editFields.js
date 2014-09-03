db.PostalCodes.update({}, {$unset : {'field3' : 0, 'field4' : 0, 'field5' : 0, 'field6' : 0, 'field7' : 0, 'field8' : 0, 'field11' : 0}}, { multi: true });
db.PostalCodes.find().snapshot().forEach(
	function(c) {
		var latitude = c.field9, longitude = c.field10;
		// old format loc, lat
		c.loc = [longitude, latitude];
		// hybrid format
		c.location = {longitude : longitude, latitude: latitude };
		delete c.field9;
		delete c.field10;
		db.PostalCodes.save(c);
})