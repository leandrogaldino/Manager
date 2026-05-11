SELECT
    p.shortname
FROM person p
LEFT JOIN personcompressor pc ON p.id = pc.personid
WHERE pc.id = @id;