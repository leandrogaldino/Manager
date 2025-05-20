SELECT
	crmtreatment.id,
	crmtreatment.creation,
	crmtreatment.responsibleid,
	crmtreatment.contact,
	crmtreatment.nextcontact,
    crmtreatment.contacttypeid,
	crmtreatment.summary
FROM crmtreatment
WHERE crmtreatment.crmid = @crmid;