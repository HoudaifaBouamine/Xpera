-- CREATE PROCEDURE GetPostsByPostIds
--    @PostIdsList NVARCHAR(MAX)
-- AS
-- BEGIN
--    SELECT pht.*, 1 AS Sep, t.*
--    FROM PostsHaveTags pht
--    JOIN Tags t ON pht.Tag_Id = t.Tag_Id
--    WHERE pht.Post_Id IN (SELECT CAST(value AS INT) FROM STRING_SPLIT(@PostIdsList, ','));
-- END;

exec GetPostsByPostIds @PostIdsList='1,2,3,4,5'