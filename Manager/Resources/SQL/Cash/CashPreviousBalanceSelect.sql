SELECT
    (SELECT 
        IFNULL(SUM(CASE WHEN cashitem2.itemtypeid = 1 THEN cashitem2.value ELSE 0 END), 0) - 
        IFNULL(SUM(CASE WHEN cashitem2.itemtypeid = 0 THEN cashitem2.value ELSE 0 END), 0) 
         FROM cash AS cash2 JOIN cashitem AS cashitem2 ON cashitem2.cashid = cash2.id WHERE cash2.id < cash.id AND cash2.cashflowid = @cashflowid
    )
FROM cash
LEFT JOIN cashitem ON cashitem.cashid = cash.id
WHERE
    cash.id = @id AND cash.cashflowid = @cashflowid
GROUP BY 
    cash.id;