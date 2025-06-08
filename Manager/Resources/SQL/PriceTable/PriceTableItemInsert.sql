INSERT INTO pricetablesellable
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