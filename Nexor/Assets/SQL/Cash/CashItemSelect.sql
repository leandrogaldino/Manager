SELECT
	cashitem.id,
	cashitem.creation,
	cashitem.itemtypeid,
	cashitem.itemcategoryid,
	cashitem.description,
	cashitem.documentdate,
	cashitem.documentnumber,
    cashitem.value
FROM cashitem
WHERE cashitem.cashid = @cashid;