SELECT
	servicepriceindicator.indicatorid,
    servicepriceindicator.price AS 'Pre�o'
FROM servicepriceindicator
WHERE servicepriceindicator.serviceid = @serviceid;