UPDATE personcontact SET
	ismaincontact = @ismaincontact,	
    name = @name,
	jobtitle = @jobtitle,
	phone = @phone,
	email = @email,
	userid = @userid
WHERE personcontact.id = @id;