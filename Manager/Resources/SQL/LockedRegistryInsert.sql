INSERT INTO lockedregistry 
(
	session,
	locktime,
	routineid,
	registryid,
	userid
)
VALUES
(
	@session,
	@locktime,
	@routineid,
	@registryid,
	@userid
)
ON DUPLICATE KEY 
UPDATE locktime = @locktime;