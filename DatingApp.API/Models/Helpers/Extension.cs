using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Models.Helpers
{
    public static class Extensions
    {
        public static void ExtAddApplicationError(this HttpResponse response, string message) 
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Header", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
        public static int ExtGetAge(this DateTime value) 
        {
            return
                Convert.ToInt16(
                    (DateTime.Now - value).TotalDays / 365
                );

        }
    }
}