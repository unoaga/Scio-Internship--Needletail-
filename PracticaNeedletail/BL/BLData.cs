using Data;
using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLData
    {
        public void CreateProjects(string datas)
        {
            MyDbData.CreateProject(datas);
        }
        public IEnumerable <Project> GetProjects()
        {
            return MyDbData.GetProjects(); 
        }

        public void DeleteProjects(Guid ProjectId)
        {
            MyDbData.DeleteProjects(ProjectId);

        }

        public void CreateAdrress(string datas)
        {
            MyDbData.CreateAdrress(datas);
        }


        public IEnumerable<Address> GetAddress() 
        {
            return MyDbData.GetAddresses();
        }
        public void DeleteAddress(Guid AddressId) 
        {
            MyDbData.DeleteAddresses(AddressId);
        }


        public void UpdateProject(string datas,Guid ProyectId) 
        {
            var _proyect = datas.Split(',');
            MyDbData.UpdateProject(new { Name = _proyect[0], Budget = decimal.Parse(_proyect[1]), StartDate = new DateTime(2014, 3, 1, 7, 0, 0) }, new { Id = ProyectId });
        }

        public void UpdateAddress(string datas, Guid AddressId) 
        {
            var _addres = datas.Split(',');
            MyDbData.UpdateAddresses(new { Street = _addres[0], ZipCode = _addres[1], Phone = _addres[2]}, new { Id = AddressId });
        }

    }
}
