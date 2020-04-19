using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactInformationCore.Model
{
    public enum Status
    {
        Activate = 1,
        Deactivate = 2
    }
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email { get; set; }

        public string Phone_Number { get; set; }

        public Status Status { get; set; }
    }
}
