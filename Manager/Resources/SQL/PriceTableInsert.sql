INSERT INTO pricetable
(
    pricetabletypeid,
    creation,
    statusid,
    name,
    userid
)
VALUES
(
    @pricetabletypeid,
    @creation,
    @statusid,
    @name,
    @userid
);