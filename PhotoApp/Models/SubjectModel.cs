using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public DateTime SubjectTime { get; set; }
        public string SubjectType { get; set; }
        public string Topic { get; set; }
        public int CoachId { get; set; }
        public string Place { get; set; }
        public int GroupId { get; set; }
        public string Status { get; set; }
    }
}