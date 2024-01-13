--CREATE PROCEDURE GetPostsHaveTags
--AS
--BEGIN
--    SELECT pht.PostHaveTag_Id, pht.Post_Id, t.*
--    FROM PostsHaveTags pht
--    JOIN Tags t ON pht.Tag_Id = t.Tag_Id;
--END;

exec GetPostsHaveTags