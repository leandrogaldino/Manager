SELECT
	state.id,
	state.name,
	state.shortname
FROM state
WHERE state.id = @id OR state.shortname =@shortname;