UPDATE productpicture SET
    picturename = @picturename,
    caption = @caption,
    userid = @userid
WHERE productpicture.id = @id;