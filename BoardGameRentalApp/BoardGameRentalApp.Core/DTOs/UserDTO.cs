using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameRentalApp.Core.DTOs
{
    public class UserDTO
    {

        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
      
    }
}
