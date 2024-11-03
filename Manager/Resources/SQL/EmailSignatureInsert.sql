INSERT INTO emailsignature
(
    ofuserid,
    creation,
    name,
    directoryname,
    userid
)
VALUES
(
    @ofuserid,
    @creation,
    @name,
    @directoryname,
    @userid
);