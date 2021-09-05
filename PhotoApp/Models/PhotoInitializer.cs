using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoApp.Models
{
    public class PhotoInitializer : DropCreateDatabaseAlways<PhotoContext>
    {
        protected override void Seed(PhotoContext db)
        {
            db.CoachModel.Add(new CoachModel { Id = 1, Fname = "2", Sname = "3", Tname = "4", Phone = "5", Email = "6" });
            db.ContractModel.Add(new ContractModel { Id = 1, ContractNumber = "2,Contract", StudentId = 1, SeasonId = 1, ContractTime = DateTime.Now, Status = "ACTIVE" });
            db.GroupModel.Add(new GroupModel { Id = 1, GroupNumber = "1", CreateDate = DateTime.Today, Satus = "active" });
            //db.GroupStudentModel.Add(new GroupStudentModel)
        
        }

    }
}