UPDATE productprovidercode SET
    ismainprovider = @ismainprovider,
    code = @code,
    providerid = @providerid,
    userid = @userid
WHERE productprovidercode.id = @id;