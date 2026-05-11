INSERT INTO city
(
    creation,
    statusid,
    name,
    bigscode,
    stateid,
    userid
)
VALUES
(
    @creation,
    @statusid,
    @name,
    @bigscode,
    @stateid,
    @userid
);