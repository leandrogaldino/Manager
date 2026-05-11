SELECT
	crmtreatment.id,
    responsible.name AS responsible,
    crmtreatment.contact,
    crmtreatment.nextcontact,
    crmtreatment.contacttypeid,
    crmtreatment.summary
FROM crmtreatment
LEFT JOIN person AS responsible ON responsible.id = crmtreatment.responsibleid
WHERE
	crmtreatment.crmid = @crmid AND
	crmtreatment.summary LIKE @summaryfilter;