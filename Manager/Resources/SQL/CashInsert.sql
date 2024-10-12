INSERT INTO cash
(
	cashflowid,
	creation,
	statusid,
    note,
	documentpath,
	userid
)
VALUES
(
	@cashflowid,
	@creation,
	@statusid,
	@note,
	@documentpath,
	@userid
);
