using System;
using System.Security.Cryptography;
using System.Text;

namespace ExtensionMethods
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            /*ExtensionMethods_Encoding(password);*/
            string result = encodeByte(password);
            string result2 = password.encodeString();
            string originalData = result2.decodeString();
            string orginalData2 = decodeByte(result);
            Console.WriteLine("--------");
            Console.WriteLine(result2);
            Console.WriteLine("--------");
            Console.WriteLine(originalData);
            Console.WriteLine("--------");
            Console.WriteLine(result);
            Console.WriteLine("--------");
            Console.WriteLine(orginalData2);
            Console.ReadLine();
        }

       public static string encodeString(this string password)
        {
            var value1 = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(value1);
        }
        public static string encodeByte(this string password)
        {
            MD5 mh = MD5.Create();
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hash = mh.ComputeHash(byt);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
       public static string decodeString(this string password)
        {
            var value3 = System.Convert.FromBase64String(password);
            return Encoding.UTF8.GetString(value3);
        }
        public static string decodeByte( this string password)
        {
            MD5 mh = MD5.Create();
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] hash = mh.ComputeHash(byt);
            string result = Convert.ToBase64String(hash);
            return result;
        }

        /*        public static void ExtensionMethods_Encoding(string password)
                {

                    MD5 mh = MD5.Create();
                    byte[] result = Encoding.ASCII.GetBytes(password);
                    byte[] hash = mh.ComputeHash(result);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    Console.WriteLine(sb.ToString());
                    Console.WriteLine(sb.Length);
                }*/

    }
}
