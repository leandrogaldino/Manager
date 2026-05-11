UPDATE evaluationcontrolledsellable SET
    currentcapacity = @currentcapacity,
    sold = @sold,
    lost = @lost,
    userid = @userid
WHERE evaluationcontrolledsellable.id = @id;