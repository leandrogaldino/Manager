UPDATE sellableprice SET
    sellabletableid = @sellabletableid,
    price = @price,
    userid = @userid
WHERE sellableprice.id = @id;