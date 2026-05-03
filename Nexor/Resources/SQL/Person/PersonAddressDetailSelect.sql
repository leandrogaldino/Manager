SELECT 
	personaddress.ismainaddress AS 'Principal',
    CASE
		WHEN personaddress.statusid = 0 THEN 'ATIVO'
        WHEN personaddress.statusid = 1 THEN 'INATIVO'
	END AS 'Status',
    CONCAT_WS(', ', personaddress.street, personaddress.number, personaddress.complement, personaddress.district, CONCAT(city.name, '-', state.shortname)) AS 'Endereço'
FROM personaddress
INNER JOIN city ON city.id = personaddress.cityid
INNER JOIN state ON state.id = city.stateid
WHERE personaddress.personid = @personid;