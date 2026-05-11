SELECT
	product.id,
	product.creation,
	product.statusid,
	product.name,
	product.internalname,
	product.location,
	product.minimumquantity,
	product.maximumquantity,
	product.unitid,
	product.familyid,
	product.groupid,
	product.grossweight,
	product.netweight,
	product.dimensions,
	product.sku,
	product.note,
	product.userid
FROM product
WHERE product.id = @id;