UPDATE evaluation SET
    isinvoicedid =  @isinvoicedid,
    userid = @userid
WHERE evaluation.id = @id;