using System;
using System.Security.Cryptography.X509Certificates;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Blog.Models;

namespace Blog;

class Program
{
    private const string CONNECTION_SRTING = @"Server=localhost,1433;Database=Blog;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";
    static void Main(string[] args)
    {
        //ReadUsers();
        //ReadUser();
        //CreateUser();
        //UpdateUser();
        DeleteUser();
    }

    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(CONNECTION_SRTING))
        {
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email, user.Bio);
                Console.ReadLine();
            }
        }
    }
    public static void ReadUser()
    {
        using (var connection = new SqlConnection(CONNECTION_SRTING))
        {
            var user = connection.Get<User>(1);
                Console.WriteLine(user.Name);
                Console.ReadLine();
        }
    }
    public static void CreateUser()
    {
        var user = new User()
        {
            Bio = "Equipe Balta.io",
            Email = "hello@balta.io",
            Image = "https://...",
            Name = "Equipe balta.io",
            PasswordHash = "HASH",
            Slug = "equipe-balta"
        };
        using (var connection = new SqlConnection(CONNECTION_SRTING))
        {
            connection.Insert<User>(user);
            Console.WriteLine("cadastro realizado com sucesso");
            Console.ReadLine();
        }
    }
    public static void UpdateUser()
    {
        var user = new User()
        {
            Id = 2,
            Bio = "Equipe | Balta.io",
            Email = "hello@balta.io",
            Image = "https://...",
            Name = "Equipe de suporte balta.io",
            PasswordHash = "HASH",
            Slug = "equipe-balta"
        };
        using (var connection = new SqlConnection(CONNECTION_SRTING))
        {
            connection.Update<User>(user);
            Console.WriteLine("Atualização realizado com sucesso");
            Console.ReadLine();
        }
    }
    public static void DeleteUser()
    {

        using (var connection = new SqlConnection(CONNECTION_SRTING))
        {
            var user = connection.Get<User>(2);
            connection.Delete<User>(user);
            Console.WriteLine("Exclusão realizado com sucesso");
            Console.ReadLine();
        }
    }
}





                

        
           




/*Console.WriteLine("Hello, World!");
Console.ReadLine();
*/
