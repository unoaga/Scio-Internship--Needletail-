using Entities;
using Needletail.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyDbData
    {
       
        public static void CreateProject(string datas)
        {
            DateTime thisDay = DateTime.Today;
            string[] d = datas.Split(',');
            Project p = new Project
            {
                Id = Guid.NewGuid(),
                Name = d[0],

                Budget = Decimal.Parse(d[1]),
                StartDate = thisDay 
            };
            MyDb.Projects.Insert(p);
        }

        public static IEnumerable<Project> GetProjects()
        {

            return MyDb.Projects.GetAll();
        }

        public static void DeleteProjects(Guid challengeId)
        {
            MyDb.Projects.Delete(where: new { Id = challengeId });

        }
        public static void UpdateProject(object values, object where)
        {
            MyDb.Projects.UpdateWithWhere(values: values, where: where);
        }

        public static void CreateAdrress(string datas)
        {
            DateTime thisDay = DateTime.Today;
            string[] d = datas.Split(',');
            Address a = new Address()
            {
                Id = Guid.NewGuid(),
                Street = d[0],
                ZipCode = d[1],
                Phone = d[2]
            };
            MyDb.Addresses.Insert(a);
        }

        public static IEnumerable<Address> GetAddresses()
        {

            return MyDb.Addresses.GetAll();
        }

        public static void DeleteAddresses(Guid challengeId)
        {
            MyDb.Addresses.Delete(where: new { Id = challengeId });

        }
        public static void UpdateAddresses(object values, object where)
        {
            MyDb.Addresses.UpdateWithWhere(values: values, where: where);
        }
    }
}
