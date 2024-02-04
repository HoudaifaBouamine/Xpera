--CREATE Procedure Get_Comments_With_Posts_By_User_Id
--    @User_Id INT
--as(

--SELECT c.*,Sep = 1,p.* FROM Comments c
--JOIN Posts p 
--ON c.Post_Id = p.Post_Id
--WHERE c.User_Id = User_Id

--)

exec Get_Comments_With_Posts_By_User_Id @User_Id = 15
