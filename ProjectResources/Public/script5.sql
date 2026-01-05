DROP TABLE agentevent;

CREATE TABLE preferences (
    id INT AUTO_INCREMENT PRIMARY KEY,
    `group` VARCHAR(100) NOT NULL,
    `key` VARCHAR(150) NOT NULL,
    `value` TEXT NULL,

    UNIQUE KEY uq_preferences_group_key (`group`, `key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Backup
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Backup', 'Monday', 'false'),
('Backup', 'Tuesday', 'false'),
('Backup', 'Wednesday', 'false'),
('Backup', 'Thursday', 'false'),
('Backup', 'Friday', 'false'),
('Backup', 'Saturday', 'false'),
('Backup', 'Sunday', 'false'),
('Backup', 'Time', '00:00:00'),
('Backup', 'Keep', '5'),
('Backup', 'IgnoreNext', 'false'),
('Backup', 'Location', NULL);

-- Support
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Support', 'EnableSSL', 'false'),
('Support', 'Email', NULL),
('Support', 'SMTPServer', NULL),
('Support', 'Port', '0'),
('Support', 'Password', NULL);

-- LastExecution
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('LastExecution', 'Backup', NULL),
('LastExecution', 'Clean', NULL),
('LastExecution', 'Release', NULL),
('LastExecution', 'CloudSync', NULL);

-- Parameters.Clean
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Clean', 'Interval', '30');

-- Parameters.Release
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Release', 'RefreshBlockedRegistryInterval', '1'),
('Release', 'ReleaseBlockedRegisterInterval', '2');

-- Parameters.Evaluation
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Evaluation', 'DaysBeforeMaintenanceAlert', '15'),
('Evaluation', 'DaysBeforeVisitAlert', '30'),
('Evaluation', 'MonthsBeforeRecordDeletion', '48'),
('Evaluation', 'FooterMaintenancePlan', NULL);

-- Parameters.User
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('User', 'DefaultPassword', '');
