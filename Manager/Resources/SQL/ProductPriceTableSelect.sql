SELECT
	sellablepricetable.id,
	sellablepricetable.creation,
    sellablepricetable.statusid,
	sellablepricetable.name
FROM sellablepricetable
WHERE sellablepricetable.id = @id;