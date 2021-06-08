using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArquivosWeb.Models;
namespace ArquivosWeb.Controllers
{

    public class ArquivosController : Controller
    {
        string diretorio = @"C:\Integrador";
        public IActionResult FileUpload()
        {
            return RedirectToAction("DownloadIndex");
        }        
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, string path)
        {      
                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName) + Path.GetExtension(file.FileName);
                    path = Path.GetFullPath(Path.Combine(diretorio, "Envio Arquivos"));
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                }
          
            return RedirectToAction(nameof(DownloadIndex));
        }
        public IActionResult DownloadIndex(string msg)
        {
            if (msg != null)
            {
                ViewBag.msg = msg;
            }

            string[] files = Directory.GetFiles(Path.Combine(diretorio, "Recebimento"));
            string[] direct = Directory.GetDirectories(Path.Combine(diretorio, "Recebimento"));
            string[] all = files.Concat(direct).ToArray();

            List<FileModel> list = new List<FileModel>();
            
            foreach (string file in all)
            {
                //difinir se é arquivo ou pasta
                list.Add( 
                    new FileModel 
                    {
                        Name = Path.GetFileName(file), 
                        Type = file.Contains(".")? "file": "folder" 
                    });;
            }
            return View(list);
        }
        public FileResult DownloadFile(string filename)
        {
            string path = Path.Combine(diretorio, "Recebimento", filename);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", filename);

        }

        public IActionResult Delete(string filepath)
        {
            string msg = "";
            string filedest = Path.Combine(diretorio, "BKP", Path.GetFileName(filepath));
            if (System.IO.File.Exists(filedest))
            {
                System.IO.File.Delete(filedest);
            }
            System.IO.File.Copy(filepath, filedest);
            System.IO.File.Delete(filepath);


            //int count = 0;
            //string fileName = filepath;
            //filepath = Path.Combine(diretorio, "Envio Arquivos/", filepath);
            //FileInfo fi = new FileInfo(filepath);
            //string filedest = Path.Combine(diretorio, "BKP/");
            //if (fi != null)
            //{

            //    try
            //    {
            //        if (System.IO.File.Exists(filedest + fileName))
            //        {
            //            System.IO.File.Copy(filepath, (filedest + count) + fileName);
            //            System.IO.File.Delete(filepath);
            //            fi.Delete();
            //        }
            //        else
            //        {
            //            System.IO.File.Copy(filepath, filedest + fileName);
            //            System.IO.File.Delete(filepath);
            //            fi.Delete();

            //        }
            //    }
            //    catch (Exception)
            //    {

            //        msg =  "Desculpe ocorreu um erro na solicitação! ";
            //    }
            //}
            return RedirectToAction("DownloadIndex", new { msg = msg});
       } 
    }
}
