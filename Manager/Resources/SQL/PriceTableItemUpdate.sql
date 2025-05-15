UPDATE pricetableitem SET
    productid = @productid,
    serviceid = @serviceid,
    price =  @price,
    userid = @userid
WHERE pricetableitem.id = @id;