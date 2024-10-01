INSERT INTO userprivilege
(
	ofuserid,
	personaccess,
	personwrite,
	persondelete,
	personchangedocument,
	personregistration,
	personmaintenanceplan,
	cityaccess,
	citywrite,
	citydelete,
	compressoraccess,
	compressorwrite,
	compressordelete,
	routeaccess,
	routewrite,
	routedelete,
	crmaccess,
	crmwrite,
	crmdelete,
	crmtreatmentdelete,
	crmtreatmentedit,
	crmchangecustomer,
	crmchangeresponsible,
	crmchangesubject,
	crmchangetopendingstatus,
	productaccess,
	productwrite,
	productdelete,
	productfamilyaccess,
	productfamilywrite,
	productfamilydelete,
	productgroupaccess,
	productgroupwrite,
	productgroupdelete,
	productpricetableaccess,
	productpricetablewrite,
	productpricetabledelete,
	productunitaccess,
	productunitwrite,
	productunitdelete,
	evaluationaccess,
	evaluationwrite,
	evaluationdelete,
	evaluationmanagementaccess,
	evaluationmanagementpanelaccess,
	evaluationapproveorreject,
	cashaccess,
	cashwrite,
	cashdelete,
	cashflowaccess,
	cashflowwrite,
	cashflowdelete,
	cashexpensesperresponsible,
	cashreopen,
	requestaccess,
	requestwrite,
	requestdelete,
	requestpendingitems,
	requestsheet,
	useraccess,
	userwrite,
	userdelete,
	userresetpassword,
	userprivilegepresetaccess,
	userprivilegepresetwrite,
	userprivilegepresetdelete,
	severalexportgrid,
	severallogaccess,
	userid
)
VALUES
(
	@ofuserid,
	@personaccess,
	@personwrite,
	@persondelete,
	@personchangedocument,
	@personregistration,
	@personmaintenanceplan,
	@cityaccess,
	@citywrite,
	@citydelete,
	@compressoraccess,
	@compressorwrite,
	@compressordelete,
	@routeaccess,
	@routewrite,
	@routedelete,
	@crmaccess,
	@crmwrite,
	@crmdelete,
	@crmtreatmentdelete,
	@crmtreatmentedit,
	@crmchangecustomer,
	@crmchangeresponsible,
	@crmchangesubject,
	@crmchangetopendingstatus,
	@productaccess,
	@productwrite,
	@productdelete,
	@productfamilyaccess,
	@productfamilywrite,
	@productfamilydelete,
	@productgroupaccess,
	@productgroupwrite,
	@productgroupdelete,
	@productpricetableaccess,
	@productpricetablewrite,
	@productpricetabledelete,
	@productunitaccess,
	@productunitwrite,
	@productunitdelete,
	@evaluationaccess,
	@evaluationwrite,
	@evaluationdelete,
	@evaluationmanagementaccess,
	@evaluationmanagementpanelaccess,
	@evaluationapproveorreject,
	@cashaccess,
	@cashwrite,
	@cashdelete,
	@cashflowaccess,
	@cashflowwrite,
	@cashflowdelete,
	@cashexpensesperresponsible,
	@cashreopen,
	@requestaccess,
	@requestwrite,
	@requestdelete,
	@requestpendingitems,
	@requestsheet,
	@useraccess,
	@userwrite,
	@userdelete,
	@userresetpassword,
	@userprivilegepresetaccess,
	@userprivilegepresetwrite,
	@userprivilegepresetdelete,
	@severalexportgrid,
	@severallogaccess,
	@userid
);
