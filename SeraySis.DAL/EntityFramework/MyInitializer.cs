using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;
using SeraySis.Entities;

namespace SeraySis.DAL.EntityFramework
{
    //Fake data ile databasein icini dolduruyorum
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Users admin = new Users()
            {
                Name = "Seray",
                Surname = "Sistem",
                Email = "seraysistem@a.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "Seray",
                ProfileImage = "",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "system"
            };
            context.Users.Add(admin);
            
            context.SaveChanges();
        }
    }
}
