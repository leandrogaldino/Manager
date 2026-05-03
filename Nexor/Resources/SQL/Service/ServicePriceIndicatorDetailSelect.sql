SELECT
	servicepriceindicator.indicatorid,
    servicepriceindicator.price AS 'Preço'
FROM servicepriceindicator
WHERE servicepriceindicator.serviceid = @serviceid;