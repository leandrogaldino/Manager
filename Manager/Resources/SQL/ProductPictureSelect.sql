SELECT
	productpicture.id,
	productpicture.creation,
	productpicture.picturepath,
	productpicture.caption
FROM productpicture
WHERE productpicture.productid = @productid;