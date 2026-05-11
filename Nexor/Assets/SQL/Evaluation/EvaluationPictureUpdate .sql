UPDATE evaluationpicture SET
    picturename =  @picturename,
    userid = @userid
WHERE evaluationpicture.id = @id;