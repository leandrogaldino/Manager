SELECT
	productpicture.id,
	productpicture.creation,
	productpicture.picturename
FROM productpicture
WHERE productpicture.productid = @productid;