SELECT 
CASE
	WHEN COUNT(user.id) = 0 THEN 0
    WHEN COUNT(user.id) > 0 THEN 1
END
FROM user
Where user.personid = @personid;
    