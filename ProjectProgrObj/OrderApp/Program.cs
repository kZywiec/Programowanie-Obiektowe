using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace OrderApp
{
    class Program
    {
        public static void Main2()
        {
            // Uwaga: zmień `DESKTOP-123ABC\SQLEXPRESS` na nazwę swojego serwera
            //        ewentualnie użyj `localhost` lub `localhost\SQLEXPRESS`

            string connectionString = @"Data Source=localhost\SQLPROGOBJ;Initial Catalog=FastFood_Sys;Integrated Security=True";

            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();

                IQueryable<UserEntity> query = from user in users
                                               where user.Role_id == 1 // user.RemovedAt == null
                                               select user;

                foreach (UserEntity user in query)
                    Console.WriteLine("{0} {1}", user.Id, user.Name);
            }
        }
    }
}
