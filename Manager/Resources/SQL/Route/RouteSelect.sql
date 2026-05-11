SELECT
	route.id,
	route.creation,
    route.statusid,
	route.name
FROM route
WHERE route.id = @id;