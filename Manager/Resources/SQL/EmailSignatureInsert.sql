INSERT INTO emailsignature
(
    ofuserid,
    creation,
    name,
    directorypath,
    userid
)
VALUES
(
    @ofuserid,
    @creation,
    @name,
    @directorypath,
    @userid
);