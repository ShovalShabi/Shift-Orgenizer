#select user();
start transaction;

drop schema if exists `swimmingclub`;
create schema `swimmingclub`;
use `swimmingclub`;


drop table if exists `timeTable`;
create table `timeTable`
(`tid` int not null auto_increment,
`hours` int,
`minutes` int,
primary key (`tid`)) engine=InnoDB auto_increment=1000 default charset=utf8mb4 collate=utf8mb4_0900_ai_ci;

lock tables `timeTable` write;
insert into `timeTable` values 
(1000,16,0),(1001,20,0), #Yotam
(1002,8,0),(1003,15,0),  #Yoni
(1004,10,0),(1005,19,0), #Jony
(1006,10,0),(1007,11,0),  #Lesson 1-Jony
(1008,17,0),(1009,18,00), #lesson 2-Yotam
(1010,12,0),(1011,13,0), #lesson 3-Jony
(1012,12,0),(1013,12,45); #lesson 4-Yoni
unlock tables;


drop table if exists `availabilityTable`;
CREATE TABLE `availabilityTable` (
  `av_id` int not null auto_increment,
  `day` varchar(15),
  `tid_min` int,
  `tid_max` int,
  primary key (`av_id`),
  constraint `fk_tid_min_availabilityTable` foreign key (`tid_min`) references `timeTable`(`tid`),
  constraint `fk_tid_max_availabilityTable` foreign key (`tid_max`) references `timeTable`(`tid`)) engine=InnoDB auto_increment=1000 default charset=utf8mb4 collate=utf8mb4_0900_ai_ci;

lock tables `availabilityTable` write;
insert into `availabilityTable` values 
(1000,'Monday',1000,1001),  #Yotam
(1001,'Thursday',1000,1001),#Yotam
(1002,'Tuesday',1002,1003),   #Yoni
(1003,'Wednesday',1002,1003), #Yoni
(1004,'Thursday',1002,1003),  #Yoni
(1005,'Sunday',1004,1005),  #Jony
(1006,'Tuesday',1004,1005), #Jony
(1007,'Thursday',1004,1005),#Jony
(1008,'Sunday',1006,1007), #Lesson 1-Jony
(1009,'Thursday',1008,1009),#lesson 2-Yotam
(1010,'Thursday',1010,1011),#lesson 3-Jony
(1011,'Wednesday',1012,1013);#lesson 4-Yoni
unlock tables;

drop table if exists `specialtyTable`;
create table `specialtyTable`
(`sp_id` int not null auto_increment,
`chest` boolean,
`front_crawl` boolean,
`back_stroke` boolean,
`butterfly_stroke` boolean,
primary key (`sp_id`)) engine=InnoDB auto_increment=1 default charset=utf8mb4 collate=utf8mb4_0900_ai_ci;

lock tables `specialtyTable` write;
insert into `specialtyTable` values 
(1000,true,true,true,true),        #Yotam --------->Hardcoded instructors from down here
(1001,true,false,false,true),      #Yoni
(1002,true,true,true,true),        #Jony
(1003,true,true,true,true),   #lesson1 shoval -----> #Hardcoded Students from down here
(1004,false,true,false,false),#lesson2 Shaked
(1005,true,false,true,false),#lesson2 Matan
(1006,true,false,false,false),#lesson2 Netanel
(1007,true,true,true,false), #lesson3 Natali
(1008,true,false,false,true),#lesson4 Daniella
(1009,true,false,false,true),#lesson4 Omer
(1010,false,false,false,true),#lesson4 Yuval
(1011,true,true,true,true),       #lesson1 -----> #Hardcodeded lessons drom down here
(1012,true,true,true,false),      #lesson2
(1013,true,true,true,false),      #lesson3
(1014,true,false,false,true);     #lesson4
unlock tables;


drop table if exists `studentTable`;
create table `studentTable`
(`sid` int not null auto_increment,
`firstname` varchar(50),
`surname` varchar(50),
`sp_id` int,
primary key (`sid`),
constraint `fk_sp_id_studentTable` foreign key (`sp_id`) references `specialtyTable`(`sp_id`)) engine=InnoDB auto_increment=1000 default charset=utf8mb4 collate=utf8mb4_0900_ai_ci;

lock tables `studentTable` write;
insert into `studentTable` values 
(1000,'Shoval','Shabi',1003),
(1001,'Shaked','Zaguri',1004),
(1002,'Matan','Bardugo',1005),
(1003,'Netanel','Habas',1006),
(1004,'Natali','Dahary',1007),
(1005,'Daniella','Vardi',1008),
(1006,'Omer','Lande',1009),
(1007,'Yuval','Mastay',1010);
unlock tables;



drop table if exists `instructorTable`;
create table `instructorTable`
(`instructor_id` int not null auto_increment,
`firstname` varchar(50),
`surname` varchar(50),
`password` varchar(15),
`sp_id` int,
primary key (`instructor_id`),
constraint `fk_sp_id_instructorTable` foreign key (`sp_id`) references `specialtyTable`(`sp_id`)) engine=InnoDB auto_increment=1000  default charset=utf8mb4 collate=utf8mb4_0900_ai_ci;

lock tables `instructorTable` write;
insert into `instructorTable` values 
(1000,'Yotam','Cohen','123456',1000),
(1001,'Yoni','Neaman','123456',1001),
(1002,'Jony','Zehavi','123456',1002);
unlock tables;



drop table if exists `lessonTable`;
create table `lessonTable`
(`lid` int not null auto_increment,
`isprivate` boolean,
`av_id` int,
`sp_id` int,
`instructor_id` int,
primary key(`lid`),
constraint `fk_av_id_lessonTable` foreign key (`av_id`) references `availabilityTable`(`av_id`),
constraint `fk_sp_id_lessonTable` foreign key (`sp_id`) references `specialtyTable`(`sp_id`),
constraint `fk_instructor_id_lessonTable` foreign key (`instructor_id`) references `instructorTable`(`instructor_id`)) engine=InnoDB auto_increment=1000 default charset=utf8mb4 collate=utf8mb4_0900_ai_ci;

lock tables `lessonTable` write;
insert into `lessonTable` values 
(1000,true,1008,1011,1002), #Jony
(1001,false,1009,1012,1000), #Yotam
(1002,true,1010,1013,1002), #Jony
(1003,false,1011,1014,1001); #Yoni
unlock tables;

drop table if exists `lessonStudentTable`;
create table `lessonStudentTable`
(`lid` int,
`sid` int,
constraint `fk_lid_lessonStudentTable` foreign key (`lid`) references `lessonTable`(`lid`),
constraint `fk_sid_lessonStudentTable` foreign key (`sid`) references `studentTable`(`sid`)) engine=InnoDB default charset=utf8mb4 collate=utf8mb4_0900_ai_ci;

lock tables `lessonStudentTable` write;
insert into `lessonStudentTable` values 
(1000,1000),
(1001,1001),
(1001,1002),
(1001,1003),
(1002,1004),
(1003,1005),
(1003,1006),
(1003,1007);
unlock tables;



drop table if exists `instructorAvailabilityTable`;
create table `instructorAvailabilityTable`
(`instructor_id` int,
`av_id` int,
constraint `fk_instructor_id_instructorAvailabilityTable` foreign key (`instructor_id`) references `instructorTable`(`instructor_id`),
constraint `fk_av_id_instructorAvailabilityTable` foreign key (`av_id`) references `availabilityTable`(`av_id`)) engine=InnoDB default charset=utf8mb4 collate=utf8mb4_0900_ai_ci;

lock tables `instructorAvailabilityTable` write;
insert into `instructorAvailabilityTable` values 
(1000,1000), #Yotam
(1000,1001), #Yotam
(1001,1002), #Yoni
(1001,1003), #Yoni
(1001,1004), #Yoni
(1002,1005), #Jony
(1002,1006), #Jony
(1002,1007); #Jony
unlock tables;

commit;