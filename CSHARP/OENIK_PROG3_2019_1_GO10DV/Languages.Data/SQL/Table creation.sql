if object_id('country_lang_link', 'U') is not null drop table country_lang_link;
if object_id('langfam_lang_link', 'U') is not null drop table langfam_lang_link;
if object_id('language_family', 'U') is not null drop table language_family;
if object_id('country', 'U') is not null drop table country;
if object_id('language', 'U') is not null drop table language;

create table language_family (
	id int identity primary key not null,
	name varchar(50) not null,
	iso_code varchar(10) not null,
	number_of_speakers bigint not null,
    rank_by_no_speakers int not null,
    number_of_languages int not null,
    rank_by_no_languages int not null
);

create table language (
	id int identity primary key not null,
	name varchar(50) not null,
	agglutinative char(1) not null,
    number_of_tenses int not null,
	no_of_noun_declension_cases int not null,
	difficulty varchar(20) not null,
	number_of_speakers int not null,
	rank_by_no_speakers int not null
);

create table country (
	id int identity primary key not null,
	name varchar(40) not null,
	population int not null,
	capital varchar(40) not null,
	continent varchar(40) not null,
	area int not null
);


create table langfam_lang_link (
	id int identity primary key not null,
	langfam_id int not null,
	lang_id int not null,
	foreign key (langfam_id) references language_family(id),
	foreign key (lang_id) references language(id)
);

create table country_lang_link (
	id int identity primary key not null,
	country_id int not null,
	lang_id int not null,
	foreign key (country_id) references country(id),
	foreign key (lang_id) references language(id)
);


insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Indo-European languages', 'ine', 3237999904, 1, 448, 5)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Sino-Tibetan languages', 'sit', 1385995195, 2, 455, 4)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Niger–Congo languages', 'nic', 519814033, 3, 1542, 1)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Afroasiatic languages', 'afa', 499294669, 4, 377, 7)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Austronesian languages', 'map', 325862510, 5, 1257, 2)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Dravidian languages', 'dra', 252807610, 6, 86, 12)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Turkic languages', 'trk', 179945933, 7, 39, 23)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Japonic languages', 'jpx', 129240180, 8, 12, 46)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Austroasiatic languages', 'aav', 116323040, 9, 167, 10)
insert into language_family (name, iso_code, number_of_speakers, rank_by_no_speakers, number_of_languages, rank_by_no_languages) values('Kra–Dai languages', 'tai', 81549828, 10, 94, 11)


insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('English', 'F', 12, 1, 'Easy', 1132000000, 1)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('Mandarin Chinese', 'F', 1, 1, 'Hard', 1160000000, 2)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('Hindi', 'F', 1, 2, 'Medium', 615400000, 3)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('Spanish', 'F', 3, 1, 'Easy', 534300000, 4)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('French', 'F', 7, 1, 'Easy', 279800000, 5)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('Standard Arabic', 'F', 3, 3, 'Hard', 273900000, 6)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('Bengali', 'F', 3, 2, 'Medium', 265000000, 7)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('Russian', 'F', 3, 6, 'Medium', 258200000, 8)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('Portuguese', 'F', 3, 1, 'Easy', 234100000, 9)
insert into language (name, agglutinative, number_of_tenses, no_of_noun_declension_cases, difficulty, number_of_speakers, rank_by_no_speakers) values('Indonesian', 'T', 1, 1, 'Easy', 198700000, 10)

insert into country(name, population, capital, continent, area) values('Russia', 144500000, 'Moscow', 'Asia', 17100000)
insert into country(name, population, capital, continent, area) values('Jordan', 9702000, 'Amman', 'Asia', 89342)
insert into country(name, population, capital, continent, area) values('France', 66990000, 'Paris', 'Europe', 643801)
insert into country(name, population, capital, continent, area) values('Mexico', 129200000, 'Mexico City', 'America', 1973000)
insert into country(name, population, capital, continent, area) values('India', 1339000000, 'New Delhi', 'Asia', 3287000)
insert into country(name, population, capital, continent, area) values('Australia', 9773000, 'Canberra', 'Australia and Oceania', 7692000)
insert into country(name, population, capital, continent, area) values('UK', 66440000, 'London', 'Europe', 242495)
insert into country(name, population, capital, continent, area) values('China', 1386000000, 'Beijing', 'Asia', 9597000)
insert into country(name, population, capital, continent, area) values('USA', 327200000, 'Washington, D.C.', 'America', 9834000)
insert into country(name, population, capital, continent, area) values('Indonesia', 264000000, 'Jakarta', 'Asia', 1905000)
insert into country(name, population, capital, continent, area) values('Hungary', 9773000, 'Budapest', 'Europe', 93030)

insert into langfam_lang_link (langfam_id, lang_id) values(1, 1)
insert into langfam_lang_link (langfam_id, lang_id) values(1, 3)
insert into langfam_lang_link (langfam_id, lang_id) values(1, 4)
insert into langfam_lang_link (langfam_id, lang_id) values(1, 5)
insert into langfam_lang_link (langfam_id, lang_id) values(1, 7)
insert into langfam_lang_link (langfam_id, lang_id) values(1, 8)
insert into langfam_lang_link (langfam_id, lang_id) values(1, 9)
insert into langfam_lang_link (langfam_id, lang_id) values(2, 2)
insert into langfam_lang_link (langfam_id, lang_id) values(4, 6)
insert into langfam_lang_link (langfam_id, lang_id) values(5, 10)

insert into country_lang_link (country_id, lang_id) values(1, 8)
insert into country_lang_link (country_id, lang_id) values(2, 6)
insert into country_lang_link (country_id, lang_id) values(3, 5)
insert into country_lang_link (country_id, lang_id) values(4, 4)
insert into country_lang_link (country_id, lang_id) values(5, 3)
insert into country_lang_link (country_id, lang_id) values(5, 1)
insert into country_lang_link (country_id, lang_id) values(6, 1)
insert into country_lang_link (country_id, lang_id) values(7, 1)
insert into country_lang_link (country_id, lang_id) values(8, 2)
insert into country_lang_link (country_id, lang_id) values(9, 1)
insert into country_lang_link (country_id, lang_id) values(10, 10)