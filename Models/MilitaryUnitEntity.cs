using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class MilitaryUnitEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ContactPersonEntity>? ContactPersons { get; set; }
        public ICollection<RequestEntity>? ActiveRequests { get; set; }
        public ICollection<RequestEntity>? CompletedRequests { get; set; }
    }
}
