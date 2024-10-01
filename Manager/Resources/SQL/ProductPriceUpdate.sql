UPDATE productprice SET

    pricetableid = @pricetableid,
    price = @price,
    userid = @userid
WHERE productprice.id = @id;