SELECT
    crm.id AS 'ID',
    crm.creation AS 'Criação', 
    CASE 
        WHEN crm.statusid = 0 THEN "PENDENTE"
        WHEN crm.statusid = 1 THEN "REALIZADO"
        WHEN crm.statusid = 2 THEN "PERDIDO"
    END AS 'Status',
    customer.shortname AS 'Cliente',
    responsible.shortname AS 'Responsável',
    crm.subject AS 'Assunto',
    treatment.contact AS 'Contato',
    treatment.nextcontact AS 'Próx. Contato'
FROM crm
LEFT JOIN person AS customer ON customer.id = crm.customerid
LEFT JOIN person AS responsible ON responsible.id = crm.responsibleid
LEFT JOIN (
            SELECT crmid, MAX(id) AS max_id
            FROM crmtreatment
            GROUP BY crmid
        ) AS latest_treatment ON latest_treatment.crmid = crm.id
LEFT JOIN crmtreatment AS treatment ON treatment.id = latest_treatment.max_id
WHERE
    FIND_IN_SET(crm.statusid, @statusid) AND
    IFNULL(customer.document,'') LIKE CONCAT('%', @customerdocument, '%') AND
    (
        IFNULL(customer.name, '') LIKE CONCAT('%', @customername, '%') OR 
        IFNULL(customer.shortname, '') LIKE CONCAT('%', @customername, '%')
    ) AND
    IFNULL(responsible.shortname, '') LIKE CONCAT('%', @responsibleshortname, '%') AND
    IFNULL(crm.subject, '') LIKE CONCAT('%', @subject, '%') AND
    treatment.contact BETWEEN @lastcontacti AND @lastcontactf AND
    treatment.nextcontact BETWEEN @nextcontacti AND @nextcontactf;
