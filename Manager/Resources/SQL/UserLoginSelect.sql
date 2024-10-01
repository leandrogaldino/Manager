SELECT 
	user.id,
	user.password
FROM user
WHERE user.username = @username;