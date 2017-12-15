drop database if exists RallyeENQ;
create database RallyeENQ;
use RallyeENQ;

Create table `Auteur` (
	`id` int(11) NOT NULL auto_increment,
	`nom` varchar(60) NOT NULL default '',
	Primary Key (`id`)
);

Create table `editeur` (
	`id` int(11) NOT NULL auto_increment,
	`nom` varchar(60) NOT NULL default '',
	Primary Key (`id`)
);

Create table `quizz` (
	`id` int(11) NOT NULL auto_increment,
	`idFiche` int(11) NOT NULL ,
	Primary Key (`id`)
);

Create table `question` (
	`id` int(11) NOT NULL auto_increment,
	`question` varchar(255) NOT NULL default '',
	`points` int(11) NOT NULL ,
	`idQuizz` int(11) NOT NULL ,
	Primary Key (`id`)
);

Create table `livre` (
	`id` int(11) NOT NULL auto_increment,
	`titre` varchar(45) NOT NULL default '',
	`couverture` varchar(100) NOT NULL default '',
	`idAuteur` int(11) NOT NULL ,
	`idEditeur` int(11) NOT NULL ,
	`idQuizz` int(11) NOT NULL ,
	Primary Key (`id`)
);

create table enseignant(
	id int auto_increment not null primary key,
	nom varchar(45) not null,
	prenom varchar(45) not null,
	login varchar(100) not null
);

create table classe(
	id int auto_increment not null primary key,
	anneeScolaire varchar(45) not null,
	idEnseignant int not null,
	idNiveau int not null
);

create table niveau(
	id int auto_increment not null primary key,
	niveauScolaire varchar(45) not null
);

create table eleve(
	id int auto_increment not null primary key,
	nom varchar(45) not null,
	prenom varchar(45) not null,
	login varchar(100) not null,
	idClasse int not null
);
create table comporter(
	idLivre int not null,
	idRallye int not null,
	Primary key(idLivre,idRallye)
);

create table rallye(
	id int not null Primary key,
	dateDebut date not null,
	duree int not null,
	theme varchar(45)
);

create table participer(
	idRallye int not null,
	idEleve int not null,
	Primary key(idRallye,idEleve)
);

create table reponse(
	idQuestion int not null,
	idProposition int not null,
	idParticiperRallye int not null,
	idParticiperEleve int not null,
	Primary key(idQuestion,idProposition,idParticiperEleve,idParticiperRallye)
);

create table proposition(
	id int not null Primary key,
	idQuestion int not null,
	proposition varchar(255),
	solution int not null
);

alter table comporter add constraint FK_comporter_idLivre foreign key (idLivre) references livre(id);
alter table comporter add constraint FK_comporter_idRallye foreign key (idRallye) references rallye(id);

alter table participer add constraint FK_participer_idRallye foreign key (idRallye) references rallye(id);
alter table participer add constraint FK_participer_idEleve foreign key (idEleve) references eleve(id);

Alter table `livre`
	add constraint FK_livre_idAuteur
	foreign key (`idAuteur`)
	references `Auteur`(`id`);

Alter table `livre`
	add constraint FK_livre_idEditeur
	foreign key (`idEditeur`)
	references `editeur`(`id`);

Alter table `livre`
	add constraint FK_livre_idQuizz
	foreign key (`idQuizz`)
	references `Quizz`(`id`);

Alter table `question`
	add constraint FK_question_idQuizz
	foreign key (`idQuizz`)
	references `Quizz`(`id`);

alter table classe add constraint FK_classe_enseignant foreign key (idEnseignant) references enseignant(id);
alter table classe add constraint FK_classe_niveau foreign key (idNiveau) references niveau (id);
alter table eleve add constraint FK_eleve_classe foreign key (idClasse) references classe (id);


Alter table `reponse`
	add constraint FK_reponse_idQuestion
	foreign key (`idQuestion`)
	references `question`(`id`);

Alter table `reponse`
	add constraint FK_reponse_idProposition
	foreign key (`idProposition`)
	references `proposition`(`id`);

Alter table `reponse`
	add constraint FK_ParticiperRallye_idParticiperRallye
	foreign key (`idParticiperRallye`)
	references `participer`(`idRallye`);

Alter table `reponse`
	add constraint FK_ParticiperEleve_idParticiperEleve
	foreign key (`idParticiperEleve`)
	references `participer`(`idEleve`);

source C:\Users\adminSio\Desktop\nolan\insertTableRallyeLecture.sql;
source C:\Users\adminSio\Desktop\nolan\aauth\Aauth_v2.sql;
source C:\Users\adminSio\Desktop\nolan\aauth\Aauth_v2_BCrypt.sql;
-- source C:\Users\adminSio\Desktop\nolan\grant.sql;