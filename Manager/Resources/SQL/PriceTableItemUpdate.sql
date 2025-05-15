UPDATE pricetableitem SET
    productid = @productid,
    serviceid = @serviceid,
    price =  @price
WHERE pricetableitem.id = @id;