SELECT 
    pc.id AS personcompressorid,
    p.shortname AS customer,
    CONCAT(c.name,'-',s.shortname) AS city,
    comp.name AS compressor,
    pc.serialnumber,
    ev.maxdate AS evaluationdate
FROM personcompressor pc
JOIN person p ON p.id = pc.personid
JOIN compressor comp ON comp.id = pc.compressorid
JOIN personaddress pa ON pa.personid = p.id
JOIN city c ON c.id = pa.cityid
JOIN state s ON s.id = c.stateid
LEFT JOIN (
    SELECT personcompressorid, MAX(evaluationdate) AS maxdate
    FROM evaluation
    WHERE statusid = 1
    GROUP BY personcompressorid
) ev ON ev.personcompressorid = pc.id
WHERE pc.controlledid = 0
  AND pa.ismainaddress = 1
  AND (ev.maxdate IS NULL OR DATE_ADD(ev.maxdate, INTERVAL @days DAY) <= CURDATE())
ORDER BY p.shortname;