INSERT INTO cash
(
	cashflowid,
	creation,
	statusid,
    note,
	documentname,
	userid
)
VALUES
(
	@cashflowid,
	@creation,
	@statusid,
	@note,
	@documentname,
	@userid
);
