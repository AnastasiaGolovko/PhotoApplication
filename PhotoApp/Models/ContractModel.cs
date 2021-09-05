using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models
{
    public class ContractModel
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public int StudentId { get; set; }
        public int SeasonId { get; set; }
        public DateTime ContractTime { get; set; }
        public string Status { get; set; }
    }
}