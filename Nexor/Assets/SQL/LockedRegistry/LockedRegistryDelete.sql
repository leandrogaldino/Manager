DELETE FROM lockedregistry
WHERE 
	session = @session AND
	routineid = @routineid AND
	registryid = @registryid AND
	userid = @userid;