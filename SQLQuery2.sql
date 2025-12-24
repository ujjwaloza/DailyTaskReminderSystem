CREATE DATABASE DailyTaskDB;
GO
use DailyTaskDB;
select *from Users;
INSERT INTO Users (FullName, Email, Password)
VALUES ('Test User', 'test@gmail.com', '1234');
