using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoApp.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string GroupNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string Satus { get; set; }
    }
}