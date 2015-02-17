using Entities;
using Needletail.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MyDb
    {
        public const string ConnectionString = "DefaultConnection";

        static DBTableDataSourceBase<Address, Guid> _Addresses = new DBTableDataSourceBase<Address, Guid>(ConnectionString, "Address");
        public static DBTableDataSourceBase<Address, Guid> Addresses
        {
            get
            {
                return _Addresses;
            }
        }


        static DBTableDataSourceBase<Project, Guid> _Projects = new DBTableDataSourceBase<Project, Guid>(ConnectionString, "Project");
        public static DBTableDataSourceBase<Project, Guid> Projects
        {
            get
            {
                return _Projects;
            }
        }


    }
}
