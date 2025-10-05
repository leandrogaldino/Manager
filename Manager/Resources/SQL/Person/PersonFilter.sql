SELECT 
	person.id AS 'ID',
    person.creation AS 'Criação',
    CASE 
		WHEN person.statusid = 0 THEN "ATIVO"
        WHEN person.statusid = 1 THEN "INATIVO"
	END AS 'Status',
    CASE 
		WHEN person.entityid = 0 THEN "PESSOA JURÍDICA"
        WHEN person.entityid = 1 THEN "PESSOA FÍSICA"
	END AS 'Entidade',
    person.document AS 'CPF/CNPJ',
    person.name AS 'Nome',
    person.shortname AS 'Nome Curto',
    REPLACE(person.note, '\n', ' ') AS 'Observação'
FROM person
LEFT JOIN personcompressor ON personcompressor.personid = person.id
LEFT JOIN compressor ON compressor.id = personcompressor.compressorid
LEFT JOIN personcontact ON personcontact.personid = person.id AND personcontact.ismaincontact = TRUE
LEFT JOIN personaddress ON personaddress.personid = person.id AND personaddress.ismainaddress = 1
LEFT JOIN city ON city.id = personaddress.cityid
LEFT JOIN state ON state.id = city.stateid
LEFT JOIN cityroute ON cityroute.cityid = city.id
LEFT JOIN route ON route.id = cityroute.routeid
WHERE
	IFNULL(person.id, '') LIKE @id AND
    IFNULL(person.statusid, '') LIKE @statusid AND
    IFNULL(person.document, '') LIKE CONCAT('%', @document, '%') AND
    (
        IFNULL(person.name, '') LIKE CONCAT('%', @name, '%') OR 
        IFNULL(person.shortname, '') LIKE CONCAT('%', @name, '%')
    ) AND
    IFNULL(person.note, '') LIKE CONCAT('%', @note, '%') AND
    IFNULL(route.name, '') LIKE CONCAT('%', @route, '%') AND
    IFNULL(person.iscustomer, '') LIKE @iscustomer AND
    IFNULL(person.isprovider, '') LIKE @isprovider AND
    IFNULL(person.isemployee, '') LIKE @isemployee AND
    IFNULL(person.istechnician, '') LIKE @istechnician AND
    IFNULL(person.iscarrier, '') LIKE @iscarrier AND    
    IFNULL(personaddress.zipcode, '') LIKE CONCAT('%', @zipcode, '%') AND
    (    
        IFNULL(personaddress.street, '') LIKE CONCAT('%', @address, '%') OR 
        IFNULL(personaddress.complement, '') LIKE CONCAT('%', @address, '%') OR 
        IFNULL(personaddress.number, '') LIKE CONCAT('%', @address, '%') OR
        IFNULL(personaddress.district, '') LIKE CONCAT('%', @address, '%')
    ) AND
    IFNULL(city.name, '') LIKE CONCAT('%', @city, '%') AND
    IFNULL(state.name, '') LIKE CONCAT('%', @state, '%') AND
    IFNULL(personcontact.name, '') LIKE CONCAT('%', @contactname, '%') AND
    IFNULL(personcontact.jobtitle, '') LIKE CONCAT('%', @contactjobtitle, '%') AND
    IFNULL(personcontact.phone, '') LIKE CONCAT('%', @contactphone, '%') AND
    IFNULL(personcontact.email, '') LIKE CONCAT('%', @contactemail, '%') AND
    IFNULL(compressor.name, '') LIKE CONCAT('%', @compressorname, '%') AND
    IFNULL(personcompressor.serialnumber, '') LIKE CONCAT('%', @compressorserialnumber, '%') AND
    IFNULL(personcompressor.patrimony, '') LIKE CONCAT('%', @compressorpatrimony, '%') AND
    IFNULL(personcompressor.sector, '') LIKE CONCAT('%', @compressorsector, '%') AND
    IFNULL(personcompressor.controlledid, '') LIKE @controlledid
GROUP BY person.id
ORDER BY person.id;