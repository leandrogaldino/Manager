UPDATE pricetablesellable SET
    productid = @productid,
    serviceid = @serviceid,
    price =  @price,
    userid = @userid
WHERE pricetablesellable.id = @id;