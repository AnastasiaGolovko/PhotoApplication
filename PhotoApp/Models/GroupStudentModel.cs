using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models
{
    public class GroupStudentModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
    }
}