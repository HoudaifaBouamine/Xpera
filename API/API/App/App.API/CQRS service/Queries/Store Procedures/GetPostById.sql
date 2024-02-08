-- CREATE PROCEDURE GetPostById
--    @Post_Id INT
-- AS
-- BEGIN
--    SELECT p.*, 1 AS Sep, u.*
--    FROM Posts p
--    JOIN Users u ON p.User_Id = u.User_Id
--    WHERE p.Post_Id = @Post_Id;
-- END;

exec GetPostById @Post_Id = 3