SELECT 
    ROUND(
        IFNULL(SUM(CASE WHEN ci.itemtypeid = 1 THEN ci.value ELSE 0 END), 0) -
        IFNULL(SUM(CASE WHEN ci.itemtypeid = 0 THEN ci.value ELSE 0 END), 0), 2
    ) AS saldo
FROM cash AS c
LEFT JOIN cashitem AS ci ON ci.cashid = c.id
WHERE c.cashflowid = @cashflowid;