UPDATE sellableprice SET
    productid = @productid,
    serviceid = @serviceid,
    sellablepricetableid = @sellablepricetableid,
    price = @price,
    userid = @userid
WHERE sellableprice.id = @id;