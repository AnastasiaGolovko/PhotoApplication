using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models
{
    public class ContractRepModel
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string Tname { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int SubjectCount { get; set; }
        public DateTime ContractTime { get; set; }
        public string Status { get; set; }
    }
}