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
        public int? Id { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Phone_Number { get; set; }

        [Required(ErrorMessage = "Status is Required")]
        public Status Status { get; set; }
    }
}
