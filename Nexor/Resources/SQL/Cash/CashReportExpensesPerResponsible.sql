SELECT 
	cashitem.documentdate  AS 'DATA',
    YEAR(cashitem.documentdate) As 'ANO',
    UPPER(MONTHNAME(cashitem.documentdate)) AS 'MÊS',
    cashitem.description AS 'DESCRIÇÃO',
    CASE
        WHEN cashitem.itemcategoryid = 0  THEN 'SUPERMERCADO'
        WHEN cashitem.itemcategoryid = 1  THEN 'ALIMENTAÇÃO'
        WHEN cashitem.itemcategoryid = 2  THEN 'COMBUSTÍVEL'
        WHEN cashitem.itemcategoryid = 3  THEN 'HOSPEDAGEM'
        WHEN cashitem.itemcategoryid = 4  THEN 'DESPESA ADM.'
        WHEN cashitem.itemcategoryid = 5  THEN 'DESPESA OP.'
        WHEN cashitem.itemcategoryid = 6  THEN 'REEMBOLSO'
        WHEN cashitem.itemcategoryid = 7  THEN 'ADIANTAMENTO PGTO'
    END AS 'CATEGORIA',
    cashitem.documentnumber 'Nº DOC.',
    person.name AS 'NOME RESPONSÁVEL',
    person.shortname AS 'NOME CURTO RESPONSÁVEL', 
    cashitem.value / (SELECT  #ESTE SELECT FAZ UMA CONTAGEM DE QUANTOS RESPONSAVEIS HÁ EM UM ITEM PARA DIVIDIR O VALOR TOTAL DO ITEM ENTRE OS RESPONSAVEIS.
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