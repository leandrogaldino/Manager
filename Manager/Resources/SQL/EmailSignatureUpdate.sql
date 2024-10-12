UPDATE emailsignature SET
    name =  @name,
    directorypath = @directorypath,
    userid = @userid
WHERE emailsignature.id = @id;