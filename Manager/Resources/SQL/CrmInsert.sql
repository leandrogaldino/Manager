INSERT INTO crm
(
	creation,
    statusid,
	customerid,
	responsibleid,
	subject,
	userid
)
VALUES
(
	@creation,
	@statusid,
	@customerid,
	@responsibleid,
	@subject,
	@userid
);
