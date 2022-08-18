using System;
namespace TaskManagerLibrary
{
    public class Constants
    {
        public const string BaseUrl = "http://localhost:7038/";

        public const string SignUpAPI = BaseUrl + "api/Employees/signup";
        public const string SignInAPI = BaseUrl + "api/Employees/signin";
        public const string CreateProjectAPI = BaseUrl + "api/Project/Post";
        public const string GetUsers = BaseUrl + "api/Employees/users";

        public static string Token = "";
    }
}

