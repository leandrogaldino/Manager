INSERT INTO user
(
    creation,
    statusid,
    username,
    password,
    personid,
    note,
    requestnewpassword,
    userid
)
VALUES
(
    @creation,
    @statusid,
    @username,
    @password,
    @personid,
    @note,
    @requestnewpassword,
    @userid
);