-- -- Get Full Post Read Dto

-- CREATE PROCEDURE GetPostsAndUsers
-- AS
-- BEGIN
--    SELECT p.Post_Id, p.Title, p.Body, p.PublishDateTime, u.*
--    FROM Posts p
--    JOIN Users u ON p.User_Id = u.User_Id;
-- END;

exec GetPostsAndUsers