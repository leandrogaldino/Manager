INSERT INTO productpicture
(
	productid,
	creation,
	picturepath,
	caption,
	userid
)
VALUES
(
	@productid,
	@creation,
	@picturepath,
	@caption,
	@userid
);
