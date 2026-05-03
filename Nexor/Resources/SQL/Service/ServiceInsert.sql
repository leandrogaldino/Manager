INSERT INTO service
(
    creation,
    statusid,
    name,
    note,
    userid
)
VALUES
(
    @creation,
    @statusid,
    @name,
    @note,
    @userid
);