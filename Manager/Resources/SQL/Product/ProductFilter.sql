SELECT DISTINCT
    product.id AS 'ID',
    product.creation AS 'Criação',
    CASE 
        WHEN product.statusid = 0 THEN "ATIVO"
        WHEN product.statusid = 1 THEN "INATIVO"
    END AS 'Status',
    code.code AS 'Código',
    product.name AS 'Nome',
    product.internalname AS 'Nome Interno',
    productfamily.name AS 'Família',
    productgroup.name AS 'Grupo',
    product.location AS 'Localização',
    product.minimumquantity AS 'Qtd. Min.',
    product.maximumquantity AS 'Qtd. Max.',
    product.grossweight AS 'Peso Bruto',
    product.netweight AS 'Peso Liq.',
    REPLACE(product.note, '\n', ' ') AS 'Observação'
FROM product
LEFT JOIN productfamily ON productfamily.id = product.familyid
LEFT JOIN productgroup ON productgroup.id = product.groupid
LEFT JOIN productprovidercode ON productprovidercode.productid = product.id
LEFT JOIN productprovidercode AS code ON code.productid = product.id AND code.ismainprovider = 1
LEFT JOIN productcode ON productcode.productid = product.id
WHERE
    IFNULL(product.id, '') LIKE @id AND
    IFNULL(product.statusid, '') LIKE @statusid AND
    (
        IFNULL(product.name, '') LIKE CONCAT('%', @name, '%') OR 
        IFNULL(product.internalname, '') LIKE CONCAT('%', @name, '%')
    ) AND
    (
        IFNULL(productprovidercode.code, '') LIKE CONCAT('%', @code, '%') OR 
        IFNULL(productcode.code, '') LIKE CONCAT('%', @code, '%')
    ) AND
    IFNULL(product.location, '') LIKE CONCAT('%', @location, '%') AND
    IFNULL(product.note, '') LIKE CONCAT('%', @note, '%') AND
    IFNULL(productfamily.name, '') LIKE CONCAT('%', @family, '%') AND
    IFNULL(productgroup.name, '') LIKE CONCAT('%', @group, '%')
ORDER BY product.id;
