UPDATE USER SET
	password = @password,
	requestnewpassword = @requestnewpassword
WHERE user.id = @id;