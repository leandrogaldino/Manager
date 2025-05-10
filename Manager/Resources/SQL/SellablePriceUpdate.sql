UPDATE sellableprice SET
    sellablepricetableid = @sellablepricetableid,
    price = @price,
    userid = @userid
WHERE sellableprice.id = @id;