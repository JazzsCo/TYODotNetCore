using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYODotNetCore.ConsoleApp.Models
{
    public class BirdModel
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
