UPDATE productpicture SET
    picturepath = @picturepath,
    caption = @caption,
    userid = @userid
WHERE productpicture.id = @id;