using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_assessment.Models
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public int Amount{ get; set; }

    }
}