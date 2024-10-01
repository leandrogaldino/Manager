SELECT 
	cashitem.documentdate  AS 'DATA',
    YEAR(cashitem.documentdate) As 'ANO',
    UPPER(MONTHNAME(cashitem.documentdate)) AS 'M�S',
    cashitem.description AS 'DESCRI��O',
    CASE
        WHEN cashitem.itemcategoryid = 0  THEN 'SUPERMERCADO'
        WHEN cashitem.itemcategoryid = 1  THEN 'ALIMENTA��O'
        WHEN cashitem.itemcategoryid = 2  THEN 'COMBUST�VEL'
        WHEN cashitem.itemcategoryid = 3  THEN 'HOSPEDAGEM'
        WHEN cashitem.itemcategoryid = 4  THEN 'DESPESA ADM.'
        WHEN cashitem.itemcategoryid = 5  THEN 'DESPESA OP.'
        WHEN cashitem.itemcategoryid = 6  THEN 'REEMBOLSO'
        WHEN cashitem.itemcategoryid = 7  THEN 'ADIANTAMENTO PGTO'
    END AS 'CATEGORIA',
    cashitem.documentnumber 'N� DOC.',
    person.name AS 'NOME RESPONS�VEL',
    person.shortname AS 'NOME CURTO RESPONS�VEL', 
    cashitem.value / (SELECT  #ESTE SELECT FAZ UMA CONTAGEM DE QUANTOS RESPONSAVEIS H� EM UM ITEM PARA DIVIDIR O VALOR TOTAL DO ITEM ENTRE OS RESPONSAVEIS.
                    COUNT(cashitemresponsible.id)
                FROM
                    cashitemresponsible
                        LEFT JOIN
                    cashitem AS cashitem2 ON cashitem2.id = cashitemresponsible.cashitemid
                WHERE
                    cashitem2.id = cashitem.id
                GROUP BY cashitem.id) AS 'VALOR'
FROM cash
LEFT JOIN cashitem ON cashitem.cashid = cash.id
LEFT JOIN cashitemresponsible ON cashitemresponsible.cashitemid = cashitem.id
LEFT JOIN person ON person.id = cashitemresponsible.responsibleid
WHERE
    cashitem.itemtypeid = 0 AND
    cashitem.documentdate BETWEEN @initialdate AND @finaldate AND
    cash.cashflowid = @cashflowid
GROUP BY cashitem.id, cashitemresponsible.id
ORDER BY NAME ASC;