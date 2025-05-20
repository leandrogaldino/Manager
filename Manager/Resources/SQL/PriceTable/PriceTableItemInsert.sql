INSERT INTO pricetableitem
(
    pricetableid,
    creation,
    productid,
    serviceid,
    price,
    userid
)
VALUES
(
    @pricetableid,
    @creation,
    @productid,
    @serviceid,
    @price,
    @userid
);