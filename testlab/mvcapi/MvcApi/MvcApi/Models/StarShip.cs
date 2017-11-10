using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApi.Models
{
    public class StarShip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CostInCredits { get; set; }
        public double hyper_drive_rating { get; set; }
    }
}