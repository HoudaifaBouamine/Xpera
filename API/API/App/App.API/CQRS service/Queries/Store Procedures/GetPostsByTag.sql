-- CREATE PROCEDURE GetPostsByTag
--    @Tag_id INT
-- AS
-- BEGIN
--    SELECT p.*, 1 AS Sep, u.*
--    FROM Posts p
--    JOIN PostsHaveTags pht ON p.Post_Id = pht.Post_Id
--    JOIN Tags t ON t.Tag_Id = pht.Tag_Id
--    JOIN Users u ON u.User_Id = p.User_Id
--    WHERE t.Tag_Id = @Tag_id;
-- END;

exec GetPostsByTag @Tag_id = 1;