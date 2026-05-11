SELECT
	city.id,
	city.creation,
    city.statusid,
	city.name,
	city.bigscode,
	city.stateid
FROM city
LEFT JOIN state ON state.id = city.stateid
WHERE city.id = @id OR (city.name = @name AND state.shortname = @state);