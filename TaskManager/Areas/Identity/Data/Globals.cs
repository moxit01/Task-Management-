using System;
using TaskManger.Areas.Identity.Pages.Account;

namespace TaskManger.Areas.Identity.Data
{

    public static class Globals
    {
        public static String AuthToken = "";
        public static UserJson? user { get; set;}

        public static String id = "";
    }
}

