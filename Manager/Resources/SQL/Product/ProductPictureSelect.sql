SELECT
	productpicture.id,
	productpicture.creation,
	productpicture.picturename,
	productpicture.caption
FROM productpicture
WHERE productpicture.productid = @productid;