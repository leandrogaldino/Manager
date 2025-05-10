INSERT INTO service
(
    creation,
    statusid,
    name,
    servicecode,
    note,
    userid
)
VALUES
(
    @creation,
    @statusid,
    @name,
    @servicecode,
    @note,
    @userid
);