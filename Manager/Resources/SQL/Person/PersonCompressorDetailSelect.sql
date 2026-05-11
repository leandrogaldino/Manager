SELECT 
    CASE
		WHEN personcompressor.statusid = 0 THEN 'ATIVO'
        WHEN personcompressor.statusid = 1 THEN 'INATIVO'
	END AS 'Status',
    compressor.name AS 'Compressor',
    CASE
		WHEN personcompressor.controlledid = 0 THEN 'SIM'
        WHEN personcompressor.controlledid = 1 THEN 'NÃO'
	END AS 'Controlado',
    personcompressor.serialnumber AS 'Nº de Série'
FROM personcompressor
INNER JOIN compressor ON compressor.id = personcompressor.compressorid
WHERE personcompressor.personid = @personid;