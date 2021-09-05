using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PhotoApp.Models
{
    public class PhotoContext : DbContext
    {

        public PhotoContext() : base("PhotoContext")
        {
        }

        public DbSet<CoachModel> CoachModel { get; set; }
        public DbSet<ContractModel> ContractModel { get; set; }
        public DbSet<GroupModel> GroupModel { get; set; }
        public DbSet<GroupStudentModel> GroupStudentModel { get; set; }
        public DbSet<SeasonModel> SeasonModel { get; set; }
        public DbSet<StudentModel> StudentModel { get; set; }
        public DbSet<SubjectModel> SubjectModel { get; set; }
        public DbSet<GroupStudentRepModel> GroupStudentRepModel { get; set; }
        public DbSet<SubjectRepModel> SubjectRepModel { get; set; }

        public DbSet<ContractRepModel> ContractRepModel { get; set; }
    }
}