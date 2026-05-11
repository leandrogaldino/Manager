SELECT
	cityroute.id,
	cityroute.cityid,
	cityroute.creation,
	cityroute.routeid
FROM cityroute
WHERE cityroute.cityid = @cityid;