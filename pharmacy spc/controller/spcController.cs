using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pharmacy_spc.module;

namespace pharmacy_spc.controller
{
    public class spcController
    {
        private static List<spc> users = new List<spc>();

        // Static method to store user credentials
        public static void StoreCredentials(string userId, string password)
        {
            var user = new spc
            {
                user_id = userId,
                password = password
            };

            users.Add(user); // Add user to the list
        }

        // Static method to get all stored users
        public static List<spc> GetUsers()
        {
            return users;
        }


    }
}