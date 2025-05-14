UPDATE pricetableitem SET
    productid = @productid,
    serviceid = @serviceid,
    price =  @price
WHERE cityroute.id = @id;