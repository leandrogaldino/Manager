UPDATE servicecomplement SET
    complement = @complement,
    userid = @userid
WHERE servicecomplement.id = @id;