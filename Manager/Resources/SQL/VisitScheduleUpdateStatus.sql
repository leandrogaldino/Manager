UPDATE visitschedule SET
    statusid =  @statusid,  
    lastupdate = @lastupdate
WHERE visitschedule.id = @id;