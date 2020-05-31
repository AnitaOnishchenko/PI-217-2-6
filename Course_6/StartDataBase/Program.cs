using DAL.Dependencies;
using DAL.Models;
using DAL.Repository;
using Ninject;

namespace StartDataBase
{
    /// <summary>
    /// Class for adding start data to database
    /// </summary>
    class Program
    {
        /// <summary>
        /// Adds start data to database
        /// </summary>
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new DataAccessModule());

            var data = kernel.Get<IUnitOfWork>();

            data.Roles.Create(new Role { RoleName = "Admin" });
            data.Roles.Create(new Role { RoleName = "Manager" });
            data.Roles.Create(new Role { RoleName = "User" });
            data.Roles.Create(new Role { RoleName = "Guest" });
            data.Save();

            data.Users.Create(new User { Login = "Admin", Pass = "Admin", RoleId = 1 });
            data.Users.Create(new User { Login = "Manager", Pass = "Manager", RoleId = 2 });
            data.Users.Create(new User { Login = "User", Pass = "User", RoleId = 3 });
            data.Users.Create(new User { Login = "Guest", Pass = "Guest", RoleId = 4 });
            data.Save();

            data.Services.Create(new Service { Name = "CarWash", Price = "200", Type = "DOM" });
            data.Save();
        }
    }
}
