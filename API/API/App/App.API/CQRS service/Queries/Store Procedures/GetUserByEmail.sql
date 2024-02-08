CREATE PROCEDURE GetUserByEmail
   @UserEmail NVARCHAR(255)
AS
BEGIN
   SELECT *
   FROM Users u
   WHERE u.Email = @UserEmail;
END

EXEC GetUserByEmail @UserEmail = 'h.bouamine@gmail.com';
