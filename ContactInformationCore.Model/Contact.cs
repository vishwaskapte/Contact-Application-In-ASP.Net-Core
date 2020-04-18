using System;
using System.Collections.Generic;
using System.Text;

namespace ContactInformationCore.Model
{
    public class Contact
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Email { get; set; }

        public string Phone_Number { get; set; }

        public bool Status { get; set; }
    }
}
