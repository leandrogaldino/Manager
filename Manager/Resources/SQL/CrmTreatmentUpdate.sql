UPDATE crmtreatment SET
	responsibleid = @responsibleid,
	contact = @contact,
	nextcontact = @nextcontact,
	contacttypeid = @contacttypeid,
    summary = @summary,
	userid = @userid
WHERE crmtreatment.id = @id;