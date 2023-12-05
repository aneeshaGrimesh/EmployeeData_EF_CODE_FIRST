using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeData.Models
{
    public class EmployeeViewModel // only for display purpose
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime DateofBirth { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Salary")]
        public double Salary { get; set; }
        [DisplayName("Name")]
        public string FullName 
        {
            get { return FirstName + "" + LastName; }
        }
    }
}
