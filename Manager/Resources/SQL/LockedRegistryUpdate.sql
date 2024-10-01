UPDATE lockedregistry SET
	locktime = @locktime
WHERE
	session = @session AND
	routineid = @routineid AND
	registryid = @registryid AND
	userid = @userid;