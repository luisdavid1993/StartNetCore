using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisFacturasWeb.Models
{
    public class LeftSidebarModel
    {
        public LeftSidebarModel() {
            UrlMenu = new List<string>();
        }
        public string UserName { get; set; }
        public List<string> UrlMenu { get; set; }
        public string Email { get; set; }
    }
}
