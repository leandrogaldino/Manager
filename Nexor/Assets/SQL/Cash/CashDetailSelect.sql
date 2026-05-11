SELECT
	CASE
		WHEN cashitem.itemtypeid = 0 THEN 'DESPESA'
        WHEN cashitem.itemtypeid = 1 THEN 'RECEITA'
	END AS 'Tipo',    
	CASE
		WHEN cashitem.itemcategoryid = 0 THEN 'SUPERMERCADO'
		WHEN cashitem.itemcategoryid = 1 THEN 'ALIMENTAÇÃO'
		WHEN cashitem.itemcategoryid = 2 THEN 'COMBUSTÍVEL'
		WHEN cashitem.itemcategoryid = 3 THEN 'HOSPEDAGEM'
		WHEN cashitem.itemcategoryid = 4 THEN 'DESPESA ADM.'
		WHEN cashitem.itemcategoryid = 5 THEN 'DESPESA OP.'
        WHEN cashitem.itemcategoryid = 6 THEN 'REEMBOLSO'
        WHEN cashitem.itemcategoryid = 7 THEN 'ADIANTAMENTO PGTO'
	END AS 'Categoria',
    cashitem.description AS 'Descrição',  
    cashitem.value AS 'Valor'
FROM cashitem
LEFT JOIN cash ON cash.id = cashitem.cashid
LEFT JOIN cashitemresponsible ON cashitemresponsible.cashitemid = cash.id
LEFT JOIN person ON person.id = cashitemresponsible.responsibleid
WHERE cashitem.cashid = @cashid
GROUP BY cashitem.id;