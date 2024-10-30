UPDATE evaluationphoto SET
    photopath =  @photopath
WHERE evaluationphoto.id = @id;