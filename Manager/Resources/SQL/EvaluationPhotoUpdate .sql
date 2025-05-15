UPDATE evaluationphoto SET
    photoname =  @photoname,
    userid = @userid
WHERE evaluationphoto.id = @id;