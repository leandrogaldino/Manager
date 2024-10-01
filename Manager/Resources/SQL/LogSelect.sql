SELECT
    log.user AS 'Usuário',
    log.id AS 'ID',
    log.fieldname AS 'Campo',
    log.oldvalue AS 'Valor Antigo',
    log.newvalue AS 'Valor Novo',
    log.changedate AS 'Data/Hora'
FROM log
WHERE log.routineid = @routineid AND log.registryid = @registryid;