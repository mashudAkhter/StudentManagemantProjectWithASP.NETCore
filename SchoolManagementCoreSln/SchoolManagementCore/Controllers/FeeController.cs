using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementCore.DAL;
using SchoolManagementCore.Models;
using SchoolManagementCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Controllers
{
    public class FeeController : Controller
    {
        private readonly ConnectionDBContext ctx;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FeeController(ConnectionDBContext context, IHostingEnvironment hostingEnvironment)
        {
            ctx = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public ActionResult Index(int? id)
        {


            var categoryWiseProductQty = from p in ctx.FeeTbls
                                         group p by p.StudentInfoId into g
                                         select new
                                         {
                                             g.FirstOrDefault().StudentInfoId,
                                             Qty = g.Sum(s => s.ExamFee)
                                         };
            var listCategory = (from c in ctx.StudentInfos
                                join cwpq in categoryWiseProductQty on c.StudentInfoId equals cwpq.StudentInfoId
                                select new VmodelStudentInfo
                                {
                                    StudentName = c.StudentName,
                                    StudentInfoId = cwpq.StudentInfoId,
                                    TotalAmount = cwpq.Qty
                                }).ToList();
            var listCourseFee = (from p in ctx.FeeTbls
                                 join c in ctx.StudentInfos on p.StudentInfoId equals c.StudentInfoId
                                 where p.StudentInfoId == id
                                 select new VmodelFeeTbl
                                 {
                                     StudentInfoId = p.StudentInfoId,
                                     StudentName = c.StudentName,
                                     AdmissionDate = p.AdmissionDate,
                                     ImagePath = p.ImagePath,
                                     CourseFee = p.CourseFee,
                                     FeeTblId = p.FeeTblId,
                                     Month = p.Month,
                                     ExamFee = p.ExamFee
                                 }).ToList();

            var oStudentWiseCourseFee = new VmStudentWiseCourseFee();
            oStudentWiseCourseFee.StudentList = listCategory;
            oStudentWiseCourseFee.CourseFeeList = listCourseFee;
            oStudentWiseCourseFee.StudentInfoId = listCourseFee.Count > 0 ? listCourseFee[0].StudentInfoId : 0;
            oStudentWiseCourseFee.StudentName = listCourseFee.Count > 0 ? listCourseFee[0].StudentName : "";

            return View(oStudentWiseCourseFee);
        }

        public ActionResult Create()
        {
            var model = new VmodelStudentCourseFee();

            model.StudentList = ctx.StudentInfos.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(StudentInfo model, string[] Month, decimal[] CourseFee, int[] ExamFee, DateTime[] AdmissionDate, IFormFile[] imgFile)
        {

            var oCatetory = (from c in ctx.StudentInfos where c.StudentName == model.StudentName.Trim() select c).FirstOrDefault();
            if (oCatetory == null)
            {
                ctx.StudentInfos.Add(model);
                ctx.SaveChanges();
            }
            else
            {
                model.StudentInfoId = oCatetory.StudentInfoId;
            }

            var listCourseFee = new List<FeeTbl>();
            for (int i = 0; i < Month.Length; i++)
            {
                string imgPaths = "";
                string imgPath = ProcessUploadFile();
                if (imgFile[i] != null && imgFile[i].Length > 0)
                {
                    //var fileName = Path.GetFileName(imgFile[i].FileName);
                    //string fileLocation = Path.Combine(
                    //    Server.MapPath("~/uploads"), fileName);
                    //imgFile[i].SaveAs(fileLocation);

                    imgPaths = imgPath;
                }

                var newCourseFee = new FeeTbl();
                newCourseFee.Month = Month[i];
                newCourseFee.ExamFee = ExamFee[i];
                newCourseFee.CourseFee = CourseFee[i];
                newCourseFee.AdmissionDate = AdmissionDate[i];
                newCourseFee.ImagePath = imgPaths;
                newCourseFee.ExamFee = ExamFee[i];
                newCourseFee.StudentInfoId = model.StudentInfoId;
                listCourseFee.Add(newCourseFee);
            }
            ctx.FeeTbls.AddRange(listCourseFee);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            var oCourseFee = (from p in ctx.FeeTbls
                              join c in ctx.StudentInfos on p.StudentInfoId equals c.StudentInfoId
                              where p.FeeTblId == id
                              select new VmodelFeeTbl
                              {
                                  StudentInfoId = p.StudentInfoId,
                                  StudentName = c.StudentName,
                                  AdmissionDate = p.AdmissionDate,
                                  ImagePath = p.ImagePath,
                                  CourseFee = p.CourseFee,
                                  FeeTblId = p.FeeTblId,
                                  Month = p.Month,
                                  ExamFee = p.ExamFee
                              }).FirstOrDefault();
            oCourseFee.StudentList = ctx.StudentInfos.ToList(); // for showing category list in view
            return View(oCourseFee);
        }

        [HttpPost]
        public ActionResult Edit(VmodelFeeTbl model)
        {

            string imgPath = ProcessUploadFile();
            string imgPaths = "";
            if (model.ImgFile != null && model.ImgFile.Length > 0)
            {
                //var fileName = Path.GetFileName(model.ImgFile.FileName);
                //string fileLocation = Path.Combine(
                //    Server.MapPath("~/uploads"), fileName);
                //model.ImgFile.SaveAs(fileLocation);

                imgPaths = imgPath;
            }

            var oCourseFee = ctx.FeeTbls.Where(w => w.FeeTblId == model.FeeTblId).FirstOrDefault();
            if (oCourseFee != null)
            {
                oCourseFee.Month = model.Month;
                oCourseFee.ExamFee = model.ExamFee;
                oCourseFee.CourseFee = model.CourseFee;
                oCourseFee.AdmissionDate = model.AdmissionDate;
                oCourseFee.StudentInfoId = model.StudentInfoId;
                if (!string.IsNullOrEmpty(imgPaths))
                {
                    //var fileName = Path.GetFileName(oCourseFee.ImagePath);
                    //string fileLocation = Path.Combine(Server.MapPath("~/uploads"), fileName);
                    //if (System.IO.File.Exists(fileLocation))
                    //{
                    //    System.IO.File.Delete(fileLocation);
                    //}
                }
                oCourseFee.ImagePath = imgPath == "" ? oCourseFee.ImagePath : imgPath;

                ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditMultiple(int id)
        {

            var oStudentWiseCourseFee = new VmStudentWiseCourseFee();
            var listCourseFee = (from p in ctx.FeeTbls
                                 join c in ctx.StudentInfos on p.StudentInfoId equals c.StudentInfoId
                                 where p.StudentInfoId == id
                                 select new VmodelFeeTbl
                                 {
                                     StudentInfoId = p.StudentInfoId,
                                     StudentName = c.StudentName,
                                     AdmissionDate = p.AdmissionDate,
                                     ImagePath = p.ImagePath,
                                     CourseFee = p.CourseFee,
                                     FeeTblId = p.FeeTblId,
                                     Month = p.Month,
                                     ExamFee = p.ExamFee
                                 }).ToList();
            oStudentWiseCourseFee.CourseFeeList = listCourseFee;
            // for showing category list in view
            oStudentWiseCourseFee.StudentList = (from c in ctx.StudentInfos
                                                 select new VmodelStudentInfo
                                                 {
                                                     StudentInfoId = c.StudentInfoId,
                                                     StudentName = c.StudentName
                                                 }).ToList();
            oStudentWiseCourseFee.StudentInfoId = listCourseFee.Count > 0 ? listCourseFee[0].StudentInfoId : 0;
            oStudentWiseCourseFee.StudentName = listCourseFee.Count > 0 ? listCourseFee[0].StudentName : "";
            return View(oStudentWiseCourseFee);
        }

        [HttpPost]
        public ActionResult EditMultiple(StudentInfo model, int[] FeeTblId, string[] Month, decimal[] CourseFee, int[] ExamFee, DateTime[] AdmissionDate, IFormFile[] imgFile)
        {

            var listCourseFee = new List<FeeTbl>();
            for (int i = 0; i < Month.Length; i++)
            {
                if (FeeTblId[i] > 0)
                {
                    string imgPath = "";
                    if (imgFile[i] != null && imgFile[i].Length > 0)
                    {
                        //var fileName = Path.GetFileName(imgFile[i].FileName);
                        //string fileLocation = Path.Combine(
                        //    Server.MapPath("~/uploads"), fileName);
                        //imgFile[i].SaveAs(fileLocation);

                        imgPath = "/uploads/" + imgFile[i].FileName;
                    }
                    int pid = FeeTblId[i];
                    var oCourseFee = ctx.FeeTbls.Where(w => w.FeeTblId == pid).FirstOrDefault();
                    if (oCourseFee != null)
                    {
                        oCourseFee.Month = Month[i];
                        oCourseFee.ExamFee = ExamFee[i];
                        oCourseFee.CourseFee = CourseFee[i];
                        oCourseFee.AdmissionDate = AdmissionDate[i];
                        oCourseFee.StudentInfoId = model.StudentInfoId;
                        if (!string.IsNullOrEmpty(imgPath))
                        {
                            //var fileName = Path.GetFileName(oCourseFee.ImagePath);
                            //string fileLocation = Path.Combine(Server.MapPath("~/uploads"), fileName);
                            //if (System.IO.File.Exists(fileLocation))
                            //{
                            //    System.IO.File.Delete(fileLocation);
                            //}
                        }
                        oCourseFee.ImagePath = imgPath == "" ? oCourseFee.ImagePath : imgPath;
                        ctx.SaveChanges();
                    }
                }
                else if (!string.IsNullOrEmpty(Month[i]))
                {
                    string imgPath = "";
                    if (imgFile[i] != null && imgFile[i].Length > 0)
                    {
                        //var fileName = Path.GetFileName(imgFile[i].FileName);
                        //string fileLocation = Path.Combine(
                        //    Server.MapPath("~/uploads"), fileName);
                        //imgFile[i].SaveAs(fileLocation);

                        imgPath = "/uploads/" + imgFile[i].FileName;
                    }

                    var newCourseFee = new FeeTbl();
                    newCourseFee.Month = Month[i];
                    newCourseFee.ExamFee = ExamFee[i];
                    newCourseFee.CourseFee = CourseFee[i];
                    newCourseFee.AdmissionDate = AdmissionDate[i];
                    newCourseFee.ImagePath = imgPath;
                    newCourseFee.ExamFee = ExamFee[i];
                    newCourseFee.StudentInfoId = model.StudentInfoId;
                    ctx.FeeTbls.Add(newCourseFee);
                    ctx.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            var oCourseFee = ctx.FeeTbls.Where(p => p.FeeTblId == id).FirstOrDefault();
            if (oCourseFee != null)
            {
                ctx.FeeTbls.Remove(oCourseFee);
                ctx.SaveChanges();

                //var fileName = Path.GetFileName(oCourseFee.ImagePath);
                //string fileLocation = Path.Combine(
                //    Server.MapPath("~/uploads"), fileName);
                // Check if file exists with its full path    
                //if (System.IO.File.Exists(fileLocation))
                //{
                //    // If file found, delete it    
                //    System.IO.File.Delete(fileLocation);
                //}
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteMultiple(int id)
        {

            var listCourseFee = ctx.FeeTbls.Where(p => p.StudentInfoId == id).ToList();
            foreach (var oCourseFee in listCourseFee)
            {
                if (oCourseFee != null)
                {
                    ctx.FeeTbls.Remove(oCourseFee);
                    ctx.SaveChanges();

                    //var fileName = Path.GetFileName(oCourseFee.ImagePath);
                    //string fileLocation = Path.Combine(
                    //    Server.MapPath("~/uploads"), fileName);
                    //// Check if file exists with its full path    
                    //if (System.IO.File.Exists(fileLocation))
                    //{
                    //    // If file found, delete it    
                    //    System.IO.File.Delete(fileLocation);
                    //}
                }
            }

            var oCategory = ctx.StudentInfos.Where(c => c.StudentInfoId == id).FirstOrDefault();
            ctx.StudentInfos.Remove(oCategory);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        private string ProcessUploadFile()
        {
            string uniqueFileName = null;
            var files = HttpContext.Request.Form.Files;
            foreach (var image in files)
            {
                if (image != null && image.Length > 0)
                {
                    var file = image;
                    var uploadFile = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    if (file.Length > 0)
                    {
                        var fileName = file.FileName;
                        using (var fileStream = new FileStream(Path.Combine(uploadFile, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            uniqueFileName = fileName;
                        }
                    }

                }
            }

            return uniqueFileName;
        }
    }
}
