using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models
{
    public class SubjectRepModel
    {
        public int Id { get; set; }
        public DateTime SubjectTime { get; set; }
        public string SubjectType { get; set; }
        public string Topic { get; set; }

        public string Fname { get; set; }
        public string Sname { get; set; }
        public string Tname { get; set; }
        public string Place { get; set; }
        public string GroupNumber { get; set; }
        public string Status { get; set; }
    }
}