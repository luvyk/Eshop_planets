drop table if EXISTS TbPlanety;

CREATE TABLE TbPlanety (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nazev VARCHAR(30) NOT NULL,
    popis VARCHAR(900) not null,
    pocet_mesicu INT,
    prumer INT,
    delka_dne TIME,
    flora_pritomna BOOLEAN,
    fauna_pritomna BOOLEAN,
    typ_planety VARCHAR(30),
    pocet_na_sklade INT,
    cena INT not null
);

drop table if EXISTS TbObjednavky;

CREATE TABLE TbObjednavky (
    id INT PRIMARY KEY Auto_Increment not null,
    jmeno varchar(30) ,
    prijmeni Varchar(30) ,
    slunecni_soustava VARCHAR(30),
    planeta VARCHAR(30) ,
    mesto VARCHAR(30),
    ulice VARCHAR(30) ,
    cislo_domu VARCHAR(30),
    psc VARCHAR(10),
    soustava_doruceni VARCHAR(30),
    zpusob_placeni VARCHAR(30)
);

drop table if EXISTS TbKategorie;

CREATE TABLE TbKategorie (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nazev VARCHAR(30) NOT NULL
);

drop table if EXISTS TbPlanetyKategorie;

CREATE TABLE TbPlanetyKategorie (
    id_kategorie int not null,
    id_planety int not null,
    FOREIGN KEY (id_kategorie) REFERENCES TbKategorie(id) ON DELETE CASCADE,
    FOREIGN KEY (id_planety) REFERENCES TbPlanety(id) ON DELETE CASCADE
);

drop table if EXISTS TbRecenze;

CREATE TABLE TbRecenze (
    id INT AUTO_INCREMENT PRIMARY KEY,
    text_recenze varchar(900),
    hodnoceni int not null,
    id_planety int not null,
    FOREIGN KEY (id_planety) REFERENCES TbPlanety(id)
);

drop table if EXISTS TbUcet;

CREATE TABLE TbUcet (
    id INT AUTO_INCREMENT PRIMARY KEY,
    uzivatelske_jmeno VARCHAR(35),
    jmeno VARCHAR(30),
    prijmeni VARCHAR(30),
    slunecni_soustava VARCHAR(40),
    planeta VARCHAR(30),
    mesto VARCHAR(30),
    cislo_domu VARCHAR(10),
    psc VARCHAR(10),
    soustava_doruceni VARCHAR(30),
    heslo VARCHAR(100),
    role VARCHAR(30)
);

drop table if EXISTS TbKosiky;

CREATE TABLE TbKosiky (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_ucet INT NOT NULL,
    id_objednavky INT,
    FOREIGN KEY (id_ucet) REFERENCES TbUcet(id) ON DELETE CASCADE,
    FOREIGN KEY (id_objednavky) REFERENCES TbObjednavky(id) ON DELETE CASCADE
);

drop table if EXISTS TbTempKosiky;

CREATE TABLE TbTempKosiky (
     uuid VARCHAR(40) PRIMARY KEY NOT NULL,
     datum_vytvoreni DATETIME,
     id_objednavky INT,
     FOREIGN KEY (id_objednavky) REFERENCES TbObjednavky(id) ON DELETE CASCADE
);

drop table if EXISTS TbPlanetyVKosiku;

CREATE TABLE TbPlanetyVKosiku (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_planety INT not null,
    id_kosiku INT,
    uuid_temp_kosiku varchar(40),
    FOREIGN KEY (id_planety) REFERENCES TbPlanety(id)/* ,
    FOREIGN KEY (id_kosiku) REFERENCES TbKosiky(id),
    FOREIGN KEY (uuid_temp_kosiku) REFERENCES TbTempKosiky(uuid) */
);




drop table TbPlanetyKategorie;
drop table TbPlanetyVKosiku;
drop table TbRecenze;
drop table TbKategorie;
drop table TbPlanety;
DROP TABLE TbKosiky;
drop table TbTempKosiky;
drop table TbUcet;
drop table TbObjednavky;


INSERT INTO `TbPlanety` 
( `nazev`, `popis`, `pocet_mesicu`, `prumer`, `delka_dne`, `flora_pritomna`, `fauna_pritomna`, `typ_planety`, `pocet_na_sklade`, `cena`)
 VALUES 
( 'Pluto', 'Ano, toto je planeta', '2', '3333', '19:46:00', '0', '0', NULL, '1', '621');
INSERT INTO `TbPlanety` (`nazev`, `popis`, `pocet_mesicu`, `prumer`, `delka_dne`, `flora_pritomna`, `fauna_pritomna`, `typ_planety`, `pocet_na_sklade`, `cena`) VALUES ('Mars', 'Rudá planeta.', '2', '3333', '17:22:29', '1', '0', 'Potenciálně obyvatelná', '1', '888');

INSERT INTO `TbKategorie` (`id`, `nazev`) VALUES ('0', 'PlazovyRezort');
INSERT INTO `TbKategorie` (`id`, `nazev`) VALUES ('0', 'KVlastniTeraformaci');

INSERT INTO `TbPlanetyKategorie` (`id_kategorie`, `id_planety`) VALUES ('1', '1');
INSERT INTO `TbPlanetyKategorie` (`id_kategorie`, `id_planety`) VALUES ('2', '2');
INSERT INTO `TbUcet` (`id`, `uzivatelske_jmeno`, `jmeno`, `prijmeni`, `slunecni_soustava`, `planeta`, `mesto`, `cislo_domu`, `psc`, `soustava_doruceni`, `heslo`, `role`) VALUES ('0', 'pepa', 't', 't', 't', 't', 't', 't', 't', 't', NULL, 'admin');
