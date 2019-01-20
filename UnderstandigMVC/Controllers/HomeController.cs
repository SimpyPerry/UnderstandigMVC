using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnderstandigMVC.Entities;
using UnderstandigMVC.Models;

namespace UnderstandigMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnderstandingMVCRepo _repo;
        private readonly IMapper _mapper;

        public HomeController(IUnderstandingMVCRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            

            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
           

            return View();
        }


        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            //Tjekker modelstate er korrekt, denne er defineret i model klasse via data annotations
            if (ModelState.IsValid)
            {
               var result = _mapper.Map<ContactViewModel, Contact>(model);
                _repo.AddContactToDB(result);
                if (_repo.SaveAll())
                {

                    //Vi kan ikke få id fra result da result bliver mappet fra ContactViewModel som ikke indeholder noget ID, til Contact der giver det et ID i Databasen
                    //hvis modellen havde et ID kunne vi bruge den til at hente dataen igen og pass dem til viewet så vi kunne bruge dem til at returne det korrekte view
                    return View();

                }


            }
          
            return View();

        }

        public IActionResult About()
        {
            ViewBag.Title = "About us";

            return View();
        }

        //Authorize fortæller at hvis man skal have tilgang til denne skal man faktisk være logget ind
        //[Authorize]
        public IActionResult Shop()
        {

            //Her bruger vi metoden til at få dataen fra gennem metoden fra interfacet
            //interface metode beskriver hvordan dataen udskrives
            var results = _repo.GetAllProducts(true);


            //Her sætter vi bare dataen i en bestemt rækkefølge
            //Den bruges hvis man ikke har et interface
            //var results = _repo.Products.OrderBy(p => p.Category).ToList();
            //parser dataen over til viewet
            return View(results);
        }

        
        public IActionResult MessageBoard()
        {
            var result = _repo.GetAllMessages();

            return View(result);
        }
        //[Route("message/{id}")]
        public IActionResult SpecificMessage(int id)
        {
            
            var result = _repo.GetMessage(id);
            
            if(result == null)
            {

            }
            return View(result);
        }
        
        
        public IActionResult EditMessage(int id)
        {

            var result = _repo.GetMessage(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult EditMessage(Contact contact)
        {
            //denne virker ikke da den hele tiden får 0 som Contactid


            //Havde været en god ide at mappe til modellen hvis den havde haft en ID værdi
            //For så kunne vi have tjekket modelstaten
            _repo.EditMessage(contact);
            if (_repo.SaveAll())
            {

                return RedirectToAction("MessageBoard");
               
            }

            return View();

        }

        //[HttpDelete]
        public IActionResult DdeleteMessage(int id)
        {
            _repo.DeleteMessage(id);
            if (_repo.SaveAll())
            {
                return RedirectToAction("MessageBoard");
            }

            return RedirectToAction("Index");
        }


    }
}
