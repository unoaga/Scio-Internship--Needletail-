using Needletail.DataAccess.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Project 

    {
        [TableKeyAttribute(CanInsertKey = true)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
     
    }
}
