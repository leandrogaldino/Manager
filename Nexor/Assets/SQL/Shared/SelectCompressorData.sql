SELECT
    c.name,
    pc.serialnumber,
    pc.sector 
FROM compressor c
LEFT JOIN personcompressor pc ON c.id = pc.compressorid
WHERE pc.id = @id;