create table _appsettings (
    id INT AUTO_INCREMENT PRIMARY KEY,
    section VARCHAR(50),
    name VARCHAR(100),
    value TEXT
);

-- ===============================
-- Inserts para _appsettings
-- ===============================

-- Company
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Document','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','LogoLocation','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Name','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','ShortName','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','CityDocument','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','StateDocument','');

-- Company > Address
INSERT INTO _appsettings (section, name, value) VALUES ('Company','ZipCode','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Street','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Number','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Complement','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','District','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','City','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','State','');

-- Company > Contact
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Phone1','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Phone2','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','CellPhone','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Email','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Facebook','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Instagram','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Linkedin','');
INSERT INTO _appsettings (section, name, value) VALUES ('Company','Site','');

-- Backup
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Monday','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Tuesday','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Wednesday','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Thursday','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Friday','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Saturday','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Sunday','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Time','00:00:00');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Keep','5');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','IgnoreNext','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Backup','Location','');

-- Database
INSERT INTO _appsettings (section, name, value) VALUES ('Database','Server','');
INSERT INTO _appsettings (section, name, value) VALUES ('Database','Name','');
INSERT INTO _appsettings (section, name, value) VALUES ('Database','Username','');
INSERT INTO _appsettings (section, name, value) VALUES ('Database','Password','');

-- General > Clean
INSERT INTO _appsettings (section, name, value) VALUES ('General','CleanInterval','30');
INSERT INTO _appsettings (section, name, value) VALUES ('General','RefreshBlockedRegistryInterval','5');
INSERT INTO _appsettings (section, name, value) VALUES ('General','ReleaseBlockedRegisterInterval','7');
INSERT INTO _appsettings (section, name, value) VALUES ('General','DaysBeforeEvaluationMaintenanceAlert','15');
INSERT INTO _appsettings (section, name, value) VALUES ('General','DaysBeforeEvaluationVisitAlert','90');
INSERT INTO _appsettings (section, name, value) VALUES ('General','MonthsBeforeEvaluationDeletion','48');
INSERT INTO _appsettings (section, name, value) VALUES ('General','UserDefaultPassword','123456');

-- Support
INSERT INTO _appsettings (section, name, value) VALUES ('Support','EnableSSL','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Support','Email','');
INSERT INTO _appsettings (section, name, value) VALUES ('Support','SMTPServer','');
INSERT INTO _appsettings (section, name, value) VALUES ('Support','Port','0');
INSERT INTO _appsettings (section, name, value) VALUES ('Support','Password','');

-- Cloud > ManagerCloud
INSERT INTO _appsettings (section, name, value) VALUES ('AppCloud','ProjectId','');
INSERT INTO _appsettings (section, name, value) VALUES ('AppCloud','JsonCredentials','');

-- Cloud > CustomerCloud
INSERT INTO _appsettings (section, name, value) VALUES ('CustomerCloud','ProjectId','');
INSERT INTO _appsettings (section, name, value) VALUES ('CustomerCloud','JsonCredentials','');
INSERT INTO _appsettings (section, name, value) VALUES ('CustomerCloud','BucketName','');
INSERT INTO _appsettings (section, name, value) VALUES ('CustomerCloud','SyncInterval','60');

-- LastExecutionDates
INSERT INTO _appsettings (section, name, value) VALUES ('LastExecutionDate','Backup','0001-01-01 00:00:00');
INSERT INTO _appsettings (section, name, value) VALUES ('LastExecutionDate','Clean','0001-01-01 00:00:00');
INSERT INTO _appsettings (section, name, value) VALUES ('LastExecutionDate','Release','0001-01-01 00:00:00');
INSERT INTO _appsettings (section, name, value) VALUES ('LastExecutionDate','CloudSync','0001-01-01 00:00:00');

-- ===============================
-- Inserts para _appsettings (License)
-- ===============================

INSERT INTO _appsettings (section, name, value) VALUES ('License','LicenseKey','');
INSERT INTO _appsettings (section, name, value) VALUES ('License','LicenseToken','');
INSERT INTO _appsettings (section, name, value) VALUES ('License','CustomerDocument','');
INSERT INTO _appsettings (section, name, value) VALUES ('License','CustomerName','');
INSERT INTO _appsettings (section, name, value) VALUES ('License','ExpirationDate','0001-01-01 00:00:00');
INSERT INTO _appsettings (section, name, value) VALUES ('License','ManagerAgentUsername','');
INSERT INTO _appsettings (section, name, value) VALUES ('License','ManagerAgentPassword','');
INSERT INTO _appsettings (section, name, value) VALUES ('License','LastOnlineValidation','0001-01-01 00:00:00');

INSERT INTO _appsettings (section, name, value) VALUES ('Secutiry','CryptoKey','');

