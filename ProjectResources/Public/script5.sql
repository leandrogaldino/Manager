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
	isactive INT NOT NULL,
    document VARCHAR(20) NOT NULL UNIQUE,
    name VARCHAR(255) NOT NULL,
    shortname VARCHAR(255) NOT NULL,
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

INSERT INTO company VALUES (1, 1, '12.764.271/0001-00','REICOL COMERCIO DE PECAS E SERVICOS', 'REICOL COMERCIO', NULL, NULL, NULL);
INSERT INTO companyaddress VALUES (1, '74.430-420', 'AV. SANTANA', '108', 'QD. 12 LT 10', 'SETOR RODOVIARIO', 'GOIANIA', 'GO');
INSERT INTO companycontact VALUES (1, '(62) 3924-6694', NULL, NULL, 'assistencia@reicolservice.com.br', NULL, NULL, NULL, NULL);

SET SQL_SAFE_UPDATES = 0;

ALTER TABLE cash ADD COLUMN companyid INT AFTER id;
UPDATE cash SET companyid = 1;
ALTER TABLE cash MODIFY companyid INT NOT NULL;
ALTER TABLE cash ADD CONSTRAINT fk_cash_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE cashflow ADD COLUMN companyid INT AFTER id;
UPDATE cashflow SET companyid=1;
ALTER TABLE cashflow MODIFY companyid INT NOT NULL;
ALTER TABLE cashflow ADD CONSTRAINT fk_cashflow_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE cashflowauthorized ADD COLUMN companyid INT AFTER id;
UPDATE cashflowauthorized SET companyid=1;
ALTER TABLE cashflowauthorized MODIFY companyid INT NOT NULL;
ALTER TABLE cashflowauthorized ADD CONSTRAINT fk_cashflowauthorized_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE cashitem ADD COLUMN companyid INT AFTER id;
UPDATE cashitem SET companyid=1;
ALTER TABLE cashitem MODIFY companyid INT NOT NULL;
ALTER TABLE cashitem ADD CONSTRAINT fk_cashitem_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE cashitemresponsible ADD COLUMN companyid INT AFTER id;
UPDATE cashitemresponsible SET companyid=1;
ALTER TABLE cashitemresponsible MODIFY companyid INT NOT NULL;
ALTER TABLE cashitemresponsible ADD CONSTRAINT fk_cashitemresponsible_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE city ADD COLUMN companyid INT AFTER id;
UPDATE city SET companyid=1;
ALTER TABLE city MODIFY companyid INT NOT NULL;
ALTER TABLE city ADD CONSTRAINT fk_city_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE cityroute ADD COLUMN companyid INT AFTER id;
UPDATE cityroute SET companyid=1;
ALTER TABLE cityroute MODIFY companyid INT NOT NULL;
ALTER TABLE cityroute ADD CONSTRAINT fk_cityroute_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE compressor ADD COLUMN companyid INT AFTER id;
UPDATE compressor SET companyid=1;
ALTER TABLE compressor MODIFY companyid INT NOT NULL;
ALTER TABLE compressor ADD CONSTRAINT fk_compressor_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE compressorinterface ADD COLUMN companyid INT AFTER id;
UPDATE compressorinterface SET companyid=1;
ALTER TABLE compressorinterface MODIFY companyid INT NOT NULL;
ALTER TABLE compressorinterface ADD CONSTRAINT fk_compressorinterface_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE compressorsellable ADD COLUMN companyid INT AFTER id;
UPDATE compressorsellable SET companyid=1;
ALTER TABLE compressorsellable MODIFY companyid INT NOT NULL;
ALTER TABLE compressorsellable ADD CONSTRAINT fk_compressorsellable_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE compressorunit ADD COLUMN companyid INT AFTER id;
UPDATE compressorunit SET companyid=1;
ALTER TABLE compressorunit MODIFY companyid INT NOT NULL;
ALTER TABLE compressorunit ADD CONSTRAINT fk_compressorunit_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE emailmodel ADD COLUMN companyid INT AFTER id;
UPDATE emailmodel SET companyid=1;
ALTER TABLE emailmodel MODIFY companyid INT NOT NULL;
ALTER TABLE emailmodel ADD CONSTRAINT fk_emailmodel_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE emailsent ADD COLUMN companyid INT AFTER id;
UPDATE emailsent SET companyid=1;
ALTER TABLE emailsent MODIFY companyid INT NOT NULL;
ALTER TABLE emailsent ADD CONSTRAINT fk_emailsent_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE emailsignature ADD COLUMN companyid INT AFTER id;
UPDATE emailsignature SET companyid=1;
ALTER TABLE emailsignature MODIFY companyid INT NOT NULL;
ALTER TABLE emailsignature ADD CONSTRAINT fk_emailsignature_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE evaluation ADD COLUMN companyid INT AFTER id;
UPDATE evaluation SET companyid=1;
ALTER TABLE evaluation MODIFY companyid INT NOT NULL;
ALTER TABLE evaluation ADD CONSTRAINT fk_evaluation_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE evaluationcontrolledsellable ADD COLUMN companyid INT AFTER id;
UPDATE evaluationcontrolledsellable SET companyid=1;
ALTER TABLE evaluationcontrolledsellable MODIFY companyid INT NOT NULL;
ALTER TABLE evaluationcontrolledsellable ADD CONSTRAINT fk_evaluationcontrolledsellable_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE evaluationpicture ADD COLUMN companyid INT AFTER id;
UPDATE evaluationpicture SET companyid=1;
ALTER TABLE evaluationpicture MODIFY companyid INT NOT NULL;
ALTER TABLE evaluationpicture ADD CONSTRAINT fk_evaluationpicture_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE evaluationreplacedsellable ADD COLUMN companyid INT AFTER id;
UPDATE evaluationreplacedsellable SET companyid=1;
ALTER TABLE evaluationreplacedsellable MODIFY companyid INT NOT NULL;
ALTER TABLE evaluationreplacedsellable ADD CONSTRAINT fk_evaluationreplacedsellable_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE evaluationtechnician ADD COLUMN companyid INT AFTER id;
UPDATE evaluationtechnician SET companyid=1;
ALTER TABLE evaluationtechnician MODIFY companyid INT NOT NULL;
ALTER TABLE evaluationtechnician ADD CONSTRAINT fk_evaluationtechnician_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE lockedregistry ADD COLUMN companyid INT FIRST;
UPDATE lockedregistry SET companyid=1;
ALTER TABLE lockedregistry MODIFY companyid INT NOT NULL;

ALTER TABLE log ADD COLUMN companyid INT AFTER id;
UPDATE log SET companyid=1;
ALTER TABLE log MODIFY companyid INT NOT NULL;

ALTER TABLE person ADD COLUMN companyid INT AFTER id;
UPDATE person SET companyid=1;
ALTER TABLE person MODIFY companyid INT NOT NULL;
ALTER TABLE person ADD CONSTRAINT fk_person_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE personaddress ADD COLUMN companyid INT AFTER id;
UPDATE personaddress SET companyid=1;
ALTER TABLE personaddress MODIFY companyid INT NOT NULL;
ALTER TABLE personaddress ADD CONSTRAINT fk_personaddress_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE personcompressor ADD COLUMN companyid INT AFTER id;
UPDATE personcompressor SET companyid=1;
ALTER TABLE personcompressor MODIFY companyid INT NOT NULL;
ALTER TABLE personcompressor ADD CONSTRAINT fk_personcompressor_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE personcompressorsellable ADD COLUMN companyid INT AFTER id;
UPDATE personcompressorsellable SET companyid=1;
ALTER TABLE personcompressorsellable MODIFY companyid INT NOT NULL;
ALTER TABLE personcompressorsellable ADD CONSTRAINT fk_personcompressorsellable_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE personcontact ADD COLUMN companyid INT AFTER id;
UPDATE personcontact SET companyid=1;
ALTER TABLE personcontact MODIFY companyid INT NOT NULL;
ALTER TABLE personcontact ADD CONSTRAINT fk_personcontact_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE pricetable ADD COLUMN companyid INT AFTER id;
UPDATE pricetable SET companyid=1;
ALTER TABLE pricetable MODIFY companyid INT NOT NULL;
ALTER TABLE pricetable ADD CONSTRAINT fk_pricetable_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE pricetablesellable ADD COLUMN companyid INT AFTER id;
UPDATE pricetablesellable SET companyid=1;
ALTER TABLE pricetablesellable MODIFY companyid INT NOT NULL;
ALTER TABLE pricetablesellable ADD CONSTRAINT fk_pricetablesellable_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE privilegepreset ADD COLUMN companyid INT AFTER id;
UPDATE privilegepreset SET companyid=1;
ALTER TABLE privilegepreset MODIFY companyid INT NOT NULL;
ALTER TABLE privilegepreset ADD CONSTRAINT fk_privilegepreset_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE privilegepresetprivilege ADD COLUMN companyid INT AFTER id;
UPDATE privilegepresetprivilege SET companyid=1;
ALTER TABLE privilegepresetprivilege MODIFY companyid INT NOT NULL;
ALTER TABLE privilegepresetprivilege ADD CONSTRAINT fk_privilegepresetprivilege_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE product ADD COLUMN companyid INT AFTER id;
UPDATE product SET companyid=1;
ALTER TABLE product MODIFY companyid INT NOT NULL;
ALTER TABLE product ADD CONSTRAINT fk_product_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE productcode ADD COLUMN companyid INT AFTER id;
UPDATE productcode SET companyid=1;
ALTER TABLE productcode MODIFY companyid INT NOT NULL;
ALTER TABLE productcode ADD CONSTRAINT fk_productcode_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE productfamily ADD COLUMN companyid INT AFTER id;
UPDATE productfamily SET companyid=1;
ALTER TABLE productfamily MODIFY companyid INT NOT NULL;
ALTER TABLE productfamily ADD CONSTRAINT fk_productfamily_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE productgroup ADD COLUMN companyid INT AFTER id;
UPDATE productgroup SET companyid=1;
ALTER TABLE productgroup MODIFY companyid INT NOT NULL;
ALTER TABLE productgroup ADD CONSTRAINT fk_productgroup_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE productpicture ADD COLUMN companyid INT AFTER id;
UPDATE productpicture SET companyid=1;
ALTER TABLE productpicture MODIFY companyid INT NOT NULL;
ALTER TABLE productpicture ADD CONSTRAINT fk_productpicture_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE productpriceindicator ADD COLUMN companyid INT AFTER id;
UPDATE productpriceindicator SET companyid=1;
ALTER TABLE productpriceindicator MODIFY companyid INT NOT NULL;
ALTER TABLE productpriceindicator ADD CONSTRAINT fk_productpriceindicator_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE productprovidercode ADD COLUMN companyid INT AFTER id;
UPDATE productprovidercode SET companyid=1;
ALTER TABLE productprovidercode MODIFY companyid INT NOT NULL;
ALTER TABLE productprovidercode ADD CONSTRAINT fk_productprovidercode_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE productunit ADD COLUMN companyid INT AFTER id;
UPDATE productunit SET companyid=1;
ALTER TABLE productunit MODIFY companyid INT NOT NULL;
ALTER TABLE productunit ADD CONSTRAINT fk_productunit_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE request ADD COLUMN companyid INT AFTER id;
UPDATE request SET companyid=1;
ALTER TABLE request MODIFY companyid INT NOT NULL;
ALTER TABLE request ADD CONSTRAINT fk_request_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE requestitem ADD COLUMN companyid INT AFTER id;
UPDATE requestitem SET companyid=1;
ALTER TABLE requestitem MODIFY companyid INT NOT NULL;
ALTER TABLE requestitem ADD CONSTRAINT fk_requestitem_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE route ADD COLUMN companyid INT AFTER id;
UPDATE route SET companyid=1;
ALTER TABLE route MODIFY companyid INT NOT NULL;
ALTER TABLE route ADD CONSTRAINT fk_route_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE service ADD COLUMN companyid INT AFTER id;
UPDATE service SET companyid=1;
ALTER TABLE service MODIFY companyid INT NOT NULL;
ALTER TABLE service ADD CONSTRAINT fk_service_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE servicecode ADD COLUMN companyid INT AFTER id;
UPDATE servicecode SET companyid=1;
ALTER TABLE servicecode MODIFY companyid INT NOT NULL;
ALTER TABLE servicecode ADD CONSTRAINT fk_servicecode_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE servicecomplement ADD COLUMN companyid INT AFTER id;
UPDATE servicecomplement SET companyid=1;
ALTER TABLE servicecomplement MODIFY companyid INT NOT NULL;
ALTER TABLE servicecomplement ADD CONSTRAINT fk_servicecomplement_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE servicepriceindicator ADD COLUMN companyid INT AFTER id;
UPDATE servicepriceindicator SET companyid=1;
ALTER TABLE servicepriceindicator MODIFY companyid INT NOT NULL;
ALTER TABLE servicepriceindicator ADD CONSTRAINT fk_servicepriceindicator_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE user ADD COLUMN companyid INT AFTER id;
UPDATE user SET companyid=1;
ALTER TABLE user MODIFY companyid INT NOT NULL;
ALTER TABLE user ADD CONSTRAINT fk_user_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE useremail ADD COLUMN companyid INT AFTER id;
UPDATE useremail SET companyid=1;
ALTER TABLE useremail MODIFY companyid INT NOT NULL;
ALTER TABLE useremail ADD CONSTRAINT fk_useremail_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE userprivilege ADD COLUMN companyid INT AFTER id;
UPDATE userprivilege SET companyid=1;
ALTER TABLE userprivilege MODIFY companyid INT NOT NULL;
ALTER TABLE userprivilege ADD CONSTRAINT fk_userprivilege_company FOREIGN KEY (companyid) REFERENCES company(id);

ALTER TABLE visitschedule ADD COLUMN companyid INT AFTER id;
UPDATE visitschedule SET companyid=1;
ALTER TABLE visitschedule MODIFY companyid INT NOT NULL;
ALTER TABLE visitschedule ADD CONSTRAINT fk_visitschedule_company FOREIGN KEY (companyid) REFERENCES company(id);



SET SQL_SAFE_UPDATES = 1;
