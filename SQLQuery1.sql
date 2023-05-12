Create Database NoteApp

use NoteApp

Create Table Note
(
Id int identity Primary key,
Title varchar(50),
Descriptionn varchar(50),
Datee date
)

select * from Note