using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GalaxyTest.Models
{
    [Owned]
    public class UserInformation
    {
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public int? Amount { get; set; }
    }
}
