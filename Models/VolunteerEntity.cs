﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class VolunteerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<MessageEntity> Messages { get; set; }
        public ICollection<VolunteerOrganizationEntity> VolunteerOrganizations { get; set; }
        public ICollection<RequestEntity> CompletedRequests { get; set; }
        public ICollection<RequestEntity> ActiveRequests { get; set; }
    }
}
