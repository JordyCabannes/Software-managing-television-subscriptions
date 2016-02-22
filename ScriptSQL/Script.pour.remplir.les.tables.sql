INSERT INTO Employe (
"numero", 
"nom", 
"prenom", 
"fonction", 
"adresse", 
"telephone", 
"salaire", 
"pseudo", 
"mot_de_passe"
)
VALUES (
101, 
'john', 
'johnny', 
'rc', 
'1 rue test', 
'0642424242', 
2000, 
'emp1', 
'toto'
);

INSERT INTO Client (
"numero", 
"nom", 
"prenom", 
"raison_sociale", 
"adresse", 
"telephone", 
"pseudo", 
"mot_de_passe"
)
VALUES (
202, 
'dupont', 
'jean', 
'', 
'2 rue test', 
'0642424243', 
'cl1', 
'toto'
);

INSERT INTO Client (
"numero", 
"nom", 
"prenom", 
"raison_sociale", 
"adresse", 
"telephone", 
"pseudo", 
"mot_de_passe"
)
VALUES (
202, 
'tata', 
'robert', 
'', 
'2 rue test', 
'0642424243', 
'cl2', 
'toto'
);

INSERT INTO ServiceDiffusion (
"numero", 
"nom" 
)
VALUES (
124, 
'Service de base'
);

INSERT INTO ServiceDiffusion (
"numero", 
"nom" 
)
VALUES (
125, 
'Service Maxi vue'
);

INSERT INTO Chaine (
"numero",
"Sigle",
"nom", 
nature, 
"prix"
)
VALUES (
6, 
'M6', 
'MaChaine6', 
'Divertissement', 
23
);

INSERT INTO Chaine (
"numero",
"Sigle",
"nom", 
nature, 
"prix"
)
VALUES (
4, 
'Canal+', 
'CanalaPlus', 
'Actualités', 
39
);

INSERT INTO Chaine (
"numero",
"Sigle",
"nom", 
nature, 
"prix"
)
VALUES (
4, 
'Arte', 
'Arte Television', 
'Reportage', 
9
);

INSERT INTO Equipement (
"numero",
"nom",
"tarif_mensuel_de_location"
)
VALUES (
1, 
'télécommande', 
15
);

INSERT INTO Equipement (
"numero",
"nom",
"tarif_mensuel_de_location"
)
VALUES (
2, 
'nouveau boitier', 
21
);

INSERT INTO Installation (
"numero",
"date_programmation",
"date_realisation",
"frais"
)
VALUES (
'123', 
'01/01/2016',
'01/11/2016',
30
);
INSERT INTO Installation (
"numero",
"date_programmation",
"date_realisation",
"frais"
)
VALUES (
'123', 
'03/01/2016',
'01/11/2016',
25
);
INSERT INTO Installation (
"numero",
"date_programmation",
"date_realisation",
"frais"
)
VALUES (
'123', 
'05/01/2016',
'01/11/2016',
20
);
INSERT INTO Installation (
"numero",
"date_programmation",
"date_realisation",
"frais"
)
VALUES (
'123', 
'06/01/2016',
'01/11/2016',
18.95
);
INSERT INTO Installation (
"numero",
"date_programmation",
"date_realisation",
"frais"
)
VALUES (
'123', 
'07/01/2016',
'01/11/2016',
16.99
);