using JustTest1.DataModel; 
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace JustTest1.Controller
{
    public class UserControlls
    {
        public static string currentUserStatus = null;

        public static string[] statusCode = new string[] { "idle", "ontheway", "arrived", "started", "working", "break","breakover", "finish", "offwork" };
        public const int AdminCode = 1;
        public const int UserCode = 2;
         

        public static async Task<User> ValidateLogin(string userName, string password)
        {  
                var user = await ParseUser.LogInAsync(userName.Trim(), password.Trim());
                 ParseFile img = user.Get<ParseFile>("profilePic");  
                 //User currentUser = new User() { Id = user.ObjectId, UserType = user.Get<int>("user_type"), Name = user.Username, Status = user.Get<string>("status"), ProfilePic = img.Url };
                 User currentUser = new User() { Id = user.ObjectId, user_type = user.Get<int>("user_type"), username = user.Username, status = user.Get<string>("status"), profilePic = img.Url };
                
            return currentUser;
        }

        public static async Task<bool> ChangeUserStatus(string userId, string newUserStatus)
        {
            bool result = false;
            try { 
                var user = await ParseUser.Query.GetAsync(userId);
                user["status"] = newUserStatus;  
                await user.SaveAsync();
                result = true;
            }
            catch { }
            return result;
        }

        public static async Task<List<User>> ListAllAvailableUsers()
        {
            List<User> listOfUsers = new List<User>();
            //IEnumerable<ParseUser> useerr = await ParseUser.Query
            //            .WhereNotEqualTo("username", "admin").WhereEqualTo("password", "admin")
            //            .FindAsync();
            IEnumerable<ParseUser> users = await ParseUser.Query
                      .WhereNotEqualTo("username", "admin").WhereEqualTo("status", "idle")
                      .FindAsync();
             
            foreach (ParseObject _user in users)
            {
                listOfUsers.Add(new User()
                {
                    Id = _user.ObjectId,
                    username = _user.Get<string>("username"),
                    //Password = _user.Get<string>("password"),
                    //Status = _user.Get<int>("status"),
                    //UserType = _user.Get<int>("user_type")
                });
            }

            return listOfUsers;
        }
       
    }
}
