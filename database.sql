drop table if EXISTS TbPlanety;

CREATE TABLE TbPlanety (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nazev VARCHAR(30) NOT NULL,
    popis VARCHAR(900) not null,
    pocet_mesicu INT,
    prumer INT,
    delka_dne DATETIME,
    flora_pritomna BOOLEAN,
    fauna_pritomna BOOLEAN,
    typ_planety VARCHAR(30),
    pocet_na_sklade INT,
    cena INT not null
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

drop table if EXISTS TbKosiky;

CREATE TABLE TbKosiky (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_ucet NOT NULL,
    id_objednavky INT
);

drop table if EXISTS TbPlanetyVKosiku;

CREATE TABLE TbPlanetyVKosiku (
    id_planety INT,
    id_kosiku NOT NULL,
    id_objednavky
);





drop table TbPlanetyKategorie;
drop table TbRecenze;
drop table TbKategorie;
drop table TbPlanety;