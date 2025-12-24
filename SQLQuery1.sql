use ITMS_DB;
UPDATE Tasks SET Status = 'To Do' WHERE Status IS NULL;
UPDATE Tasks SET Status = 'In Progress' WHERE Status IN ('InProgress');
UPDATE Tasks SET Status = 'Completed' WHERE Status IN ('Done');
