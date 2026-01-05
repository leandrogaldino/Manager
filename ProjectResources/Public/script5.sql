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

-- Clean
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Clean', 'Interval', '30');

-- Release
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Release', 'RefreshBlockedRegistryInterval', '1'),
('Release', 'ReleaseBlockedRegisterInterval', '2');

-- Evaluation
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Evaluation', 'DaysBeforeMaintenanceAlert', '15'),
('Evaluation', 'DaysBeforeVisitAlert', '30'),
('Evaluation', 'MonthsBeforeRecordDeletion', '48'),
('Evaluation', 'FooterMaintenancePlan', NULL);

-- User
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('User', 'DefaultPassword', '');

-- Sync
INSERT INTO preferences (`group`, `key`, `value`) VALUES
('Sync', 'Interval', '10');

CREATE TABLE company (
    id INT AUTO_INCREMENT PRIMARY KEY,
    document VARCHAR(20) NOT NULL UNIQUE,
    name VARCHAR(255),
    shortname VARCHAR(255),
    logoname VARCHAR(500),
    citydocument VARCHAR(20),
    statedocument VARCHAR(20)
) ENGINE=InnoDB;

CREATE TABLE companyaddress (
    companyid INT PRIMARY KEY,
    zipcode VARCHAR(20),
    street VARCHAR(255),
    number VARCHAR(20),
    complement VARCHAR(255),
    district VARCHAR(255),
    city VARCHAR(255),
    state VARCHAR(50),
    FOREIGN KEY (companyid) REFERENCES company(id) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE companycontact (
    companyid INT PRIMARY KEY,
    phone1 VARCHAR(50),
    phone2 VARCHAR(50),
    cellphone VARCHAR(50),
    email VARCHAR(255),
    facebook VARCHAR(255),
    instagram VARCHAR(255),
    linkedin VARCHAR(255),
    site VARCHAR(255),
    FOREIGN KEY (companyid) REFERENCES company(id) ON DELETE CASCADE
) ENGINE=InnoDB;
