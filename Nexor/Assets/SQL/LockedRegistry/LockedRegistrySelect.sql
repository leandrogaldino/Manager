SELECT
	session,
	locktime,
	userid
FROM lockedregistry
WHERE 
	routineid = @routineid AND
	registryid = @registryid;