INSERT INTO evaluation
(
	creation,
    statusid,
	evaluationtypeid,
	evaluationdate,
	starttime,
	endtime,
	evaluationnumber,
	customerid,
	responsible,
	personcompressorid,
	horimeter,
	manualaverageworkload,
	averageworkload,
	technicaladvice,
	documentpath,
	rejectreason,
	userid
)
VALUES
(
	@creation,
	@statusid,
	@evaluationtypeid,
	@evaluationdate,
	@starttime,
	@endtime,
	@evaluationnumber,
	@customerid,
	@responsible,
	@personcompressorid,
	@horimeter,
	@manualaverageworkload,
	@averageworkload,
	@technicaladvice,
	@documentpath,
	@rejectreason,
	@userid
);
