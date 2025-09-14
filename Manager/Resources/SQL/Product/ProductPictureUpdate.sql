UPDATE productpicture SET
    picturename = @picturename,
    userid = @userid
WHERE productpicture.id = @id;