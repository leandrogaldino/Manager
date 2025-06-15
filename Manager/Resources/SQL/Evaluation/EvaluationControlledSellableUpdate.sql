UPDATE evaluationpart SET
    currentcapacity = @currentcapacity,
    sold = @sold,
    lost = @lost,
    userid = @userid
WHERE evaluationpart.id = @id;