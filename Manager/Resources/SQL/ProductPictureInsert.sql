INSERT INTO productpicture
(
	productid,
	creation,
	picturename,
	caption,
	userid
)
VALUES
(
	@productid,
	@creation,
	@picturename,
	@caption,
	@userid
);
