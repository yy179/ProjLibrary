using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class ContactPersonEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MilitaryUnitId { get; set; }
        public MilitaryUnitEntity MilitaryUnit { get; set; }


    }
}
