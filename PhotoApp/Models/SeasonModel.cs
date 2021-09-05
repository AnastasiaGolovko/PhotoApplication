using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models
{
    public class SeasonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int SubjectCount { get; set; }
    }
}