using Microsoft.Reporting.WebForms;
using PhotoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhotoApp.Controllers
{
    public class HomeController : Controller
    {
        PhotoContext db = new PhotoContext();
        public ActionResult Index()
        {
            IEnumerable<CoachModel> coach = db.CoachModel;
            ViewBag.CoachModel = coach;
            //CoachModel coach1 = new CoachModel { Id = 1, Fname = "2", Sname = "3", Tname = "4", Phone = "5", Email = "6" };
            //db.CoachModel.Add(coach1);
            return View();
        }

        public ActionResult Load()
        {
            
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddCoach(CoachModel coach)
        {
            IEnumerable<CoachModel> coachAdd = db.CoachModel;
            ViewBag.CoachModel = coachAdd;
            return View();
        }
        public ActionResult AddContract(ContractModel coach)
        {
            IEnumerable<StudentModel> studentAdd = db.StudentModel;
            ViewBag.StudentModel = studentAdd;
            IEnumerable<SeasonModel> seasonAdd = db.SeasonModel;
            ViewBag.SeasonModel = seasonAdd;
            IEnumerable<ContractModel> contractAdd = db.ContractModel;
            ViewBag.ContractModel = contractAdd;
            return View();
        }
        public ActionResult AddGroup(GroupModel coach)
        {
            IEnumerable<StudentModel> studentAdd = db.StudentModel;
            ViewBag.StudentModel = studentAdd;
            IEnumerable<GroupModel> seasonAdd = db.GroupModel;
            ViewBag.GroupModel = seasonAdd;
            return View();
        }

        public ActionResult AddSeason()
        {
            IEnumerable<SeasonModel> seasonAdd = db.SeasonModel;
            ViewBag.SeasonModel = seasonAdd;
            return View();
        }
        public ActionResult AddStudent()
        {
            IEnumerable<StudentModel> studentAdd = db.StudentModel;
            ViewBag.StudentModel = studentAdd;
            return View();
        }
        public ActionResult AddSubject(CoachModel coach)
        {
            IEnumerable<CoachModel> coachAdd = db.CoachModel;
            ViewBag.CoachModel = coachAdd;
            IEnumerable<GroupModel> seasonAdd = db.GroupModel;
            ViewBag.GroupModel = seasonAdd;
            IEnumerable<SubjectModel> SubjectAdd = db.SubjectModel;
            ViewBag.SubjectModel = SubjectAdd;
            return View();
        }

        public ActionResult Ready()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult AddCoachPost(CoachModel coach)
        {
            var worker = new CoachModel();
            worker.Fname = coach.Fname.ToString();
            worker.Sname = coach.Sname.ToString();
            if (coach.Tname != null)
                worker.Tname = coach.Tname.ToString();
            else
                worker.Tname = null;
            worker.Phone = coach.Phone.ToString();
            worker.Email = coach.Email.ToString();
            db.CoachModel.Add(worker);
            db.SaveChanges();
            return View("Ready");
        }
        [HttpPost]
        public ActionResult AddStudentPost(StudentModel coach)
        {
            var worker = new StudentModel();
            worker.Fname = coach.Fname.ToString();
            worker.Sname = coach.Sname.ToString();
            if (coach.Tname != null) 
                worker.Tname = coach.Tname.ToString();
            else
                worker.Tname = null;
            worker.Phone = coach.Phone.ToString();
            worker.Email = coach.Email.ToString();
            db.StudentModel.Add(worker);
            db.SaveChanges();
            return View("Ready");
        }
        
        [HttpPost]
        public ActionResult AddSeasonPost(SeasonModel coach)
        {
            var worker = new SeasonModel();
            worker.Name = coach.Name;
            worker.Cost = coach.Cost;
            worker.SubjectCount = coach.SubjectCount;
            db.SeasonModel.Add(worker);
            db.SaveChanges();
            return View("Ready");
        }
        [HttpPost]
        public ActionResult AddGroupPost(GroupModel coach)
        {
            var worker = new GroupModel();
            worker.GroupNumber = coach.GroupNumber;
            worker.CreateDate = coach.CreateDate;
            worker.Satus = coach.Satus;
            db.GroupModel.Add(worker);
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult AddContractPost(ContractModel coach)
        {
            var worker = new ContractModel();
            worker.ContractNumber = coach.ContractNumber;
            worker.ContractTime = coach.ContractTime;
            worker.StudentId = coach.StudentId;
            worker.SeasonId = coach.SeasonId;
            worker.Status = coach.Status;
            db.ContractModel.Add(worker);

            var conrep = new ContractRepModel();
            conrep.ContractNumber = coach.ContractNumber;
            conrep.ContractTime = coach.ContractTime;
            conrep.Status = coach.Status;
            foreach (var a in db.StudentModel)
            {
                if (a.Id == coach.StudentId)
                {
                    conrep.Fname = a.Fname;
                    conrep.Sname = a.Sname;
                    conrep.Tname = a.Tname;
                    break;
                }
            }
            foreach (var b in db.SeasonModel)
            {
                if (b.Id == coach.SeasonId)
                {
                    conrep.Cost = b.Cost;
                    conrep.Name = b.Name;
                    conrep.SubjectCount = b.SubjectCount;
                    break;
                }
            }
            db.ContractRepModel.Add(conrep);
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult AddSubjectPost(SubjectModel coach)
        {
            var worker = new SubjectModel();
            worker.SubjectTime = coach.SubjectTime;
            worker.GroupId = coach.GroupId;
            worker.Place = coach.Place;
            worker.SubjectType = coach.SubjectType;
            worker.Status = coach.Status;
            worker.Topic = coach.Topic;
            worker.CoachId = coach.CoachId;
            db.SubjectModel.Add(worker);
            db.SaveChanges();

            var srep = new SubjectRepModel();
            srep.SubjectTime = coach.SubjectTime;
            srep.Place = coach.Place;
            srep.SubjectType = coach.SubjectType;
            srep.Status = coach.Status;
            srep.Topic = coach.Topic;
            foreach (var a in db.GroupModel)
            {
                if (a.Id == coach.GroupId)
                {
                    srep.GroupNumber = a.GroupNumber;

                    break;
                }
            }
            foreach (var b in db.CoachModel)
            {
                if (b.Id == coach.CoachId)
                {
                    srep.Fname = b.Fname;
                    srep.Sname = b.Sname;
                    srep.Tname = b.Tname;
                    db.SubjectRepModel.Add(srep);
                    
                    break;
                }
            }
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult EditSubject(SubjectModel coach)
        {
            var worker = new SubjectModel();
            foreach (var a in db.SubjectModel)
            {
                if (a.Id == coach.Id)
                {
                    worker.Id = a.Id;
                    if (coach.GroupId != 0)
                    {
                        worker.GroupId = coach.GroupId;
                    }
                    else
                        worker.GroupId = a.GroupId;
                    if (coach.Place != null)
                    {
                        worker.Place = coach.Place;
                    }
                    else
                        worker.Place = a.Place;
                    if (coach.Status != null)
                    {
                        worker.Status = coach.Status;
                    }
                    else
                        worker.Status = a.Status;
                    if (coach.SubjectTime != null)
                    {
                        worker.SubjectTime = coach.SubjectTime;
                    }
                    else
                        worker.SubjectTime = a.SubjectTime;
                    if (coach.SubjectType != null)
                    {
                        worker.SubjectType = coach.SubjectType;
                    }
                    else
                        worker.SubjectType = a.SubjectType;
                    if (coach.Topic != null)
                    {
                        worker.Topic = coach.Topic;
                    }
                    else
                        worker.Topic = a.Topic;
                    db.SubjectModel.Remove(a);
                    break;
                }
            }
            db.SubjectModel.Add(worker);
            db.SaveChanges();
            

            var srep = new SubjectRepModel();
            srep.SubjectTime = worker.SubjectTime;
            srep.Place = worker.Place;
            srep.SubjectType = worker.SubjectType;
            srep.Status = worker.Status;
            srep.Topic = worker.Topic;
            foreach (var a in db.GroupModel)
            {
                if (a.Id == worker.GroupId)
                {
                    srep.GroupNumber = a.GroupNumber;

                    break;
                }
            }
            foreach (var b in db.CoachModel)
            {
                if (b.Id == worker.CoachId)
                {
                    srep.Fname = b.Fname;
                    srep.Sname = b.Sname;
                    srep.Tname = b.Tname;
                    db.SubjectRepModel.Add(srep);

                    break;
                }
            }
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult DeleteSubjectPost(SubjectModel coach)
        {
            var worker = new SubjectModel();
            foreach (var a in db.SubjectModel)
            {
                if (a.Id == coach.Id)
                {
                    db.SubjectModel.Remove(a);
                    foreach (var b in db.SubjectRepModel)
                    { 
                        if(a.SubjectTime == b.SubjectTime) //костыль
                        db.SubjectRepModel.Remove(b); 
                    }
                    break;
                }
            }
               
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult AddStudentsGroupPost(GroupStudentModel coach)
        {
            var worker = new GroupStudentModel();
            worker.GroupId = coach.GroupId;
            worker.StudentId = coach.StudentId;
            db.GroupStudentModel.Add(worker);
            db.SaveChanges();
            var groupst = new GroupStudentRepModel();
            foreach (var a in db.GroupModel)
            {
                if (a.Id == coach.GroupId)
                {                    
                    groupst.GroupNumber = a.GroupNumber;                    
                    
                    break;
                }
            }
            foreach (var b in db.StudentModel)
            {
                if (b.Id == coach.StudentId)
                {
                    groupst.Fname = b.Fname;
                    groupst.Sname = b.Sname;
                    groupst.Tname = b.Tname; 
                    db.GroupStudentRepModel.Add(groupst);
                    break;
                }
            }
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult EditCoachPost(CoachModel coach)
        {
            var worker = new CoachModel();
            foreach (var a in db.CoachModel)
            {
                if (a.Id == coach.Id)
                {
                    worker.Id = a.Id;
                    if (coach.Fname != null)
                    {
                        worker.Fname = coach.Fname;
                    } else
                        worker.Fname = a.Fname;
                    if (coach.Sname != null)
                    {
                        worker.Sname = coach.Sname;
                    }
                    else
                        worker.Sname = a.Sname;
                    if (coach.Tname != null)
                    {
                        worker.Tname = coach.Tname;
                    }
                    else
                        worker.Tname = a.Tname;
                    if (coach.Phone != null)
                    {
                        worker.Phone = coach.Phone;
                    }
                    else
                        worker.Phone = a.Phone;
                    if (coach.Email != null)
                    {
                        worker.Email = coach.Email;
                    }
                    else
                        worker.Email = a.Email;
                    db.CoachModel.Remove(a);
                    break;
                }
            }
            
            db.CoachModel.Add(worker);
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult EditStudentPost(StudentModel coach)
        {
            var worker = new StudentModel();
            foreach (var a in db.StudentModel)
            {
                if (a.Id == coach.Id)
                {
                    worker.Id = a.Id;
                    if (coach.Fname != null)
                    {
                        worker.Fname = coach.Fname;
                    }
                    else
                        worker.Fname = a.Fname;
                    if (coach.Sname != null)
                    {
                        worker.Sname = coach.Sname;
                    }
                    else
                        worker.Sname = a.Sname;
                    if (coach.Tname != null)
                    {
                        worker.Tname = coach.Tname;
                    }
                    else
                        worker.Tname = a.Tname;
                    if (coach.Phone != null)
                    {
                        worker.Phone = coach.Phone;
                    }
                    else
                        worker.Phone = a.Phone;
                    if (coach.Email != null)
                    {
                        worker.Email = coach.Email;
                    }
                    else
                        worker.Email = a.Email;
                    db.StudentModel.Remove(a);
                    break;
                }
            }

            db.StudentModel.Add(worker);
            db.SaveChanges();
            return View("Ready");
        }


        [HttpPost]
        public ActionResult EditGroup (GroupModel coach)
        {
            var worker = new GroupModel();
            var ab = coach.CreateDate.ToString();
            foreach (var a in db.GroupModel)
            {
                if (a.Id == coach.Id)
                {
                    worker.Id = a.Id;
                    if (coach.GroupNumber != null)
                    {
                        worker.GroupNumber = coach.GroupNumber;
                    }
                    else
                        worker.GroupNumber = a.GroupNumber;
                    if (coach.CreateDate.ToString() != "1/1/0001 12:00:00 AM")
                    {
                        worker.CreateDate = coach.CreateDate;
                    }
                    else
                        worker.CreateDate = a.CreateDate;
                    if (coach.Satus != null)
                    {
                        worker.Satus = coach.Satus;
                    }
                    else
                        worker.Satus = a.Satus;
                    db.GroupModel.Remove(a);
                    break;
                }
            }

            db.GroupModel.Add(worker);
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult EditContract(ContractModel coach)
        {
            var worker = new ContractModel();
            foreach (var a in db.ContractModel)
            {
                if (a.Id == coach.Id)
                {
                    worker.Id = a.Id;
                    if (coach.ContractNumber != null)
                    {
                        worker.ContractNumber = coach.ContractNumber;
                    }
                    else
                        worker.ContractNumber = a.ContractNumber;
                    if (coach.ContractTime.ToString() != "1/1/0001 12:00:00 AM")
                    {
                        worker.ContractTime = coach.ContractTime;
                    }
                    else
                        worker.ContractTime = a.ContractTime;
                    if (coach.SeasonId != 0)
                    {
                        worker.SeasonId = coach.SeasonId;
                    }
                    else
                        worker.SeasonId = a.SeasonId;
                    if (coach.Status != null)
                    {
                        worker.Status = coach.Status;
                    }
                    else
                        worker.Status = a.Status;
                    if (coach.StudentId != 0)
                    {
                        worker.StudentId = coach.StudentId;
                    }
                    else
                        worker.StudentId = a.StudentId;
                    db.ContractModel.Remove(a);
                    break;
                }
            }

            var conrep = new ContractRepModel();
            conrep.ContractNumber = coach.ContractNumber;
            conrep.ContractTime = coach.ContractTime;
            conrep.Status = coach.Status;
            foreach (var a in db.StudentModel)
            {
                if (a.Id == coach.StudentId)
                {
                    conrep.Fname = a.Fname;
                    conrep.Sname = a.Sname;
                    conrep.Tname = a.Tname;
                    break;
                }
            }
            foreach (var b in db.SeasonModel)
            {
                if (b.Id == coach.SeasonId)
                {
                    conrep.Cost = b.Cost;
                    conrep.SubjectCount = b.SubjectCount;
                    break;
                }
            }
            db.ContractRepModel.Add(conrep);
            db.SaveChanges();
            return View("Ready");
        }

        [HttpPost]
        public ActionResult EditSeason(SeasonModel coach)
        {
            var worker = new SeasonModel();
            foreach (var a in db.SeasonModel)
            {
                if (a.Id == coach.Id)
                {
                    worker.Id = a.Id;
                    if (coach.Name != null)
                    {
                        worker.Name = coach.Name;
                    }
                    else
                        worker.Name = a.Name;
                    if (coach.Cost != 0)
                    {
                        worker.Cost = coach.Cost;
                    }
                    else
                        worker.Cost = a.Cost;
                    if (coach.SubjectCount != 0)
                    {
                        worker.SubjectCount = coach.SubjectCount;
                    }
                    else
                        worker.SubjectCount = a.SubjectCount;
                    db.SeasonModel.Remove(a);
                    break;
                }
            }

            db.SeasonModel.Add(worker);
            db.SaveChanges();
            return View("Ready");
        }

        public ActionResult GroupRep(string ReportType)
        {
            LocalReport rep1 = new LocalReport();
            rep1.ReportPath = Server.MapPath("~/Reports/GroupRep.rdlc");
            ReportDataSource reportdata = new ReportDataSource();
            reportdata.Name = "GroupRep";
            reportdata.Value = db.GroupStudentRepModel.ToList();

            ReportDataSource reportdata1 = new ReportDataSource();
            reportdata1.Name = "SubjectRep";
            reportdata1.Value = db.SubjectRepModel.ToList();

            ReportDataSource reportdata2 = new ReportDataSource();
            reportdata2.Name = "ContractRep";
            reportdata2.Value = db.ContractRepModel.ToList();

            rep1.DataSources.Add(reportdata);
            rep1.DataSources.Add(reportdata1);
            rep1.DataSources.Add(reportdata2);
            string rtype = ReportType;
            string gettype;
            string encording;
            string filenameExtention = "xlsx";
            string[] utildata;
            Warning[] Alerts;
            byte[] renderByte;
            renderByte = rep1.Render(rtype, "", out gettype, out encording, out filenameExtention, out utildata, out Alerts);
            Response.AddHeader("content-disposition", "attachment;filename=GroupRep." + filenameExtention);
            return File(renderByte, filenameExtention);
        }

        
    }
}