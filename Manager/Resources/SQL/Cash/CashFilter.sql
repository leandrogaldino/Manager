SELECT
    cash.id,
    cash.creation As 'Criação',
    CASE 
		WHEN cash.statusid = 0 THEN "ABERTO"
        WHEN cash.statusid = 1 THEN "FECHADO"
	END AS 'Status',
    cash.note AS 'Observação',    
    ROUND((SELECT 
        IFNULL(SUM(CASE WHEN cashitem2.itemtypeid = 1 THEN cashitem2.value ELSE 0 END), 0) - 
        IFNULL(SUM(CASE WHEN cashitem2.itemtypeid = 0 THEN cashitem2.VALUE ELSE 0 END), 0) 
         FROM cash AS cash2 JOIN cashitem AS cashitem2 ON cashitem2.cashid = cash2.id WHERE cash2.id < cash.id AND cash2.cashflowid = @cashflowid
    ), 2)  AS 'Saldo Anterior',
	ROUND(IFNULL((SELECT SUM(CASE WHEN expense.itemtypeid = 1 THEN expense.VALUE ELSE 0 END) FROM cashitem AS expense WHERE expense.itemtypeid= 1 AND expense.cashid = cash.id), 0), 2) AS 'Receita',
    ROUND(IFNULL((SELECT SUM(CASE WHEN expense.itemtypeid = 0 THEN expense.VALUE ELSE 0 END) FROM cashitem AS expense WHERE expense.itemtypeid= 0 AND expense.cashid = cash.id), 0), 2) AS 'Despesa',
    /*Saldo Anterior + Reembolso - Despesas = Saldo Atual*/
    ROUND(
    (SELECT 
        IFNULL(SUM(CASE WHEN cashitem2.itemtypeid = 1 THEN cashitem2.value ELSE 0 END), 0) - 
        IFNULL(SUM(CASE WHEN cashitem2.itemtypeid = 0 THEN cashitem2.VALUE ELSE 0 END), 0) 
         FROM cash AS cash2 JOIN cashitem AS cashitem2 ON cashitem2.cashid = cash2.id WHERE cash2.id < cash.id AND cash2.cashflowid = @cashflowid
    ) + 
    IFNULL((SELECT SUM(CASE WHEN expense.itemtypeid = 1 THEN expense.VALUE ELSE 0 END) FROM cashitem AS expense WHERE expense.itemtypeid= 1 AND expense.cashid = cash.id), 0) -
    IFNULL((SELECT SUM(CASE WHEN expense.itemtypeid = 0 THEN expense.VALUE ELSE 0 END) FROM cashitem AS expense WHERE expense.itemtypeid= 0 AND expense.cashid = cash.id), 0)
    , 2)  AS 'Saldo Atual'
FROM cash
LEFT JOIN cashitem ON cashitem.cashid = cash.id
LEFT JOIN cashitemresponsible ON cashitemresponsible.cashitemid = cashitem.id
LEFT JOIN person ON person.id = cashitemresponsible.responsibleid
WHERE
    cash.cashflowid = @cashflowid AND
    IFNULL(cash.id, '') LIKE @id AND
    IFNULL(cash.statusid, '') LIKE @statusid AND
    IFNULL(cash.note, '') LIKE CONCAT('%', @note, '%') AND
    IFNULL(cashitem.description,'') LIKE CONCAT('%', @description, '%') AND
    IFNULL(cashitem.documentnumber, '') LIKE @documentnumber AND
    IFNULL(person.id,'') LIKE @responsibleid AND 
    IFNULL(person.document,'') LIKE @responsibledocument AND 
    IFNULL(person.name,'') LIKE CONCAT('%', @responsiblename, '%') AND
    IFNULL(person.shortname,'') LIKE CONCAT('%', @responsiblename, '%') AND
    cashitem.value BETWEEN @valuemin AND @valuemax AND
    cashitem.documentdate BETWEEN @documentdatei AND @documentdatef AND
    cash.creation BETWEEN @creationi AND @creationf
GROUP BY cash.id
ORDER BY cash.id;