SELECT
	servicepriceindicator.id,
	servicepriceindicator.creation,
	servicepriceindicator.serviceid,
    servicepriceindicator.indicatorid,
    servicepriceindicator.price
FROM servicepriceindicator
WHERE servicepriceindicator.serviceid = @serviceid;