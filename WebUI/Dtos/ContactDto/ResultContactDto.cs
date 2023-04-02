using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.ContactDto
{
    public class ResultContactDto
    {
        public int ContactID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
