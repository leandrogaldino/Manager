UPDATE evaluationtechnician SET
    technicianid =  @technicianid,
    userid = @userid
WHERE evaluationtechnician.id = @id;