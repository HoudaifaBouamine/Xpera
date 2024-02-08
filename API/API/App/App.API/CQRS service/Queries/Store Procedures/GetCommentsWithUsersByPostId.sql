-- CREATE Procedure Get_Comments_With_Users_By_Post_Id
--     @Post_Id INT
-- as(

-- SELECT c.*,Sep=1,u.* FROM Comments c
-- JOIN Users u 
-- ON c.User_Id = u.User_Id
-- WHERE c.Post_Id = @Post_Id

-- )

exec Get_Comments_With_Users_By_Post_Id @Post_Id = 2
