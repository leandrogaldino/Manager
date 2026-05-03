UPDATE emailsignature SET
    name =  @name,
    directoryname = @directoryname,
    userid = @userid
WHERE emailsignature.id = @id;