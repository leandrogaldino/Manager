UPDATE useremail SET
    ismainemail = @ismainemail,
    host =  @host,
    port = @port,
    email = @email,
    password = @password,
    enablessl = @enablessl,
    userid = @userid
WHERE useremail.id = @id;