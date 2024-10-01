SELECT
	userprivilege.id,
	userprivilege.personaccess,
	userprivilege.personwrite,
	userprivilege.persondelete,
	userprivilege.personchangedocument,
	userprivilege.personregistration,
	userprivilege.personmaintenanceplan,
	userprivilege.cityaccess,
    userprivilege.citywrite,
	userprivilege.citydelete,
	userprivilege.compressoraccess,
	userprivilege.compressorwrite,
	userprivilege.compressordelete,
	userprivilege.routeaccess,
	userprivilege.routewrite,
	userprivilege.routedelete,	
	userprivilege.crmaccess,
	userprivilege.crmwrite,
	userprivilege.crmdelete,
	userprivilege.crmtreatmentdelete,
	userprivilege.crmtreatmentedit,
	userprivilege.crmchangecustomer,
	userprivilege.crmchangeresponsible,
	userprivilege.crmchangesubject,
	userprivilege.crmchangetopendingstatus,
	userprivilege.productaccess,
	userprivilege.productwrite,
	userprivilege.productdelete,
	userprivilege.productfamilyaccess,
	userprivilege.productfamilywrite,
	userprivilege.productfamilydelete,
	userprivilege.productgroupaccess,
	userprivilege.productgroupwrite,
	userprivilege.productgroupdelete,
	userprivilege.productpricetableaccess,
	userprivilege.productpricetablewrite,
	userprivilege.productpricetabledelete,
	userprivilege.productunitaccess,
	userprivilege.productunitwrite,
	userprivilege.productunitdelete,
	userprivilege.evaluationaccess,
	userprivilege.evaluationwrite,
	userprivilege.evaluationdelete,
	userprivilege.evaluationmanagementaccess,
	userprivilege.evaluationmanagementpanelaccess,
	userprivilege.evaluationapproveorreject,
	userprivilege.cashaccess,
	userprivilege.cashwrite,
	userprivilege.cashdelete,
	userprivilege.cashflowaccess,
	userprivilege.cashflowwrite,
	userprivilege.cashflowdelete,
	userprivilege.cashexpensesperresponsible,
	userprivilege.cashreopen,
	userprivilege.requestaccess,
	userprivilege.requestwrite,
	userprivilege.requestdelete,
	userprivilege.requestpendingitems,
	userprivilege.requestsheet,
	userprivilege.useraccess,
	userprivilege.userwrite,
	userprivilege.userdelete,
	userprivilege.userresetpassword,
	userprivilege.userprivilegepresetaccess,
	userprivilege.userprivilegepresetwrite,
	userprivilege.userprivilegepresetdelete,
	userprivilege.severalexportgrid,
	userprivilege.severallogaccess
FROM userprivilege
WHERE userprivilege.ofuserid = @ofuserid;