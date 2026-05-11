UPDATE emailmodel SET
    name =  @name,
    subject = @subject,
    body = @body,
    signatureid = @signatureid,
    userid = @userid
WHERE emailmodel.id = @id;