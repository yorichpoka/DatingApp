using System;

namespace DatingApp.API.Models.Static
{
    internal static class Tools
    {
        internal static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hMac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hMac.Key;
                passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        internal static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hMac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computerHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
                for(int i = 0; i < computerHash.Length; i++)
                {
                    if(computerHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

        
        internal static void ToLower(ref string value)
        {
            value = value.ToLower();
        }
    }
}