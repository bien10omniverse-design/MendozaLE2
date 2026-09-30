using BlogDataLibrary.Database;
using BlogDataLibrary.Models;

namespace BlogDataLibrary.Data
{
    public class SqlData
    {
        private readonly ISqlDataAccess _db;

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }

        public List<UserModel> LoadUsers()
        {
            string sql = "SELECT Id, UserName, FirstName, LastName, Password FROM Users;";

            return _db.LoadData<UserModel, dynamic>(
                sql,
                new { },
                "Default",
                false);
        }

        public void CreateUser(UserModel user)
        {
            string sql = @"INSERT INTO Users
                           (UserName, FirstName, LastName, Password)
                           VALUES
                           (@UserName, @FirstName, @LastName, @Password);";

            _db.SaveData(
                sql,
                user,
                "Default",
                false);
        }

        public List<ListPostModel> LoadPosts()
        {
            string sql = @"SELECT p.Id, p.Title, p.Body, p.DateCreated,
                                  u.UserName, u.FirstName, u.LastName
                           FROM Posts p
                           INNER JOIN Users u ON p.UserId = u.Id;";

            return _db.LoadData<ListPostModel, dynamic>(
                sql,
                new { },
                "Default",
                false);
        }

        public void CreatePost(PostModel post)
        {
            string sql = @"INSERT INTO Posts
                           (UserId, Title, Body, DateCreated)
                           VALUES
                           (@UserId, @Title, @Body, @DateCreated);";

            _db.SaveData(
                sql,
                post,
                "Default",
                false);
        }
    }
}