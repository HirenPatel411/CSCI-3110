//////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	File Name:         HomeController.cs
//
//	Course:            CSCI 3110
//	Author:            Hiren Patel, East Tennessee State University
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.AspNetCore.Mvc;
using PatelHiren_Assignment1.Models;
using System.Diagnostics;
using System.Linq;

namespace PatelHiren_Assignment1.Controllers
{
    /// <summary>
    /// This is the HomeController class
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;   //logging interface for home controller  
        enum Make { Acura };                                //Enum for car model
        enum Model { ILX, TLX, RDX, MDX, NSX };             //Enum for car make

        /// <summary>
        /// HomeController logging interface 
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        /// <summary>
        /// Displays the home page.
        /// </summary>
        /// <returns>view</returns>
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// This action shows that /welcome is working in the address bar.
        /// </summary>
        /// <returns></returns>
        public IActionResult Welcome()
        {
            int assignmentNum = 1;
            return Content($"Hello, Welcome to Assignment {assignmentNum}!");
        }



        /// <summary>
        /// This action method displays an example of enum type
        /// </summary>
        /// <returns>information of example</returns>
        public IActionResult EnumType(string acuraModel)
        {
            Make carModel = Make.Acura;
            string makes = $"{carModel} makes the following cars\n{acuraModel}";
            foreach (string item in Enum.GetNames(typeof(Model)))
            {
                makes += item + "\n";

            }
            return Content(makes);
        }



        /// <summary>
        /// This class demonstrates class types 
        /// </summary>
        public class Acura
        {
            public string Name { get; set; }

            public virtual string Car()
            {
                return Name + " is the fastest car Acura makes";
            }
        }
        /// <summary>
        /// This class demonstrates class types 
        /// </summary>
        public class Price : Acura
        {
            public override string Car()
            {
                return Name + "STARTS AT $169,500!!";
            }
        }
        /// <summary>
        /// This action method displays an example of class type
        /// </summary>
        /// <returns>information of example</returns>
        public IActionResult ClassType()
        {
            Acura a = new Acura
            {
                Name = "The Acura NSX Type S Supercar"
            };
            Price p = new Price
            {
                Name = "and it "
            };
            string sent = a.Car();
            sent += " ";
            sent += p.Car();
            return Content(sent);
        }
        


        /// <summary>
        /// This action method displays an example of array type
        /// </summary>
        /// <returns>information of example</returns>
        public IActionResult ArrayType()
        {
            int[] arrayPrice = { 27300, 37700, 40100, 48000 };

            return Content("The sum of every base model Acura is $" + arrayPrice.Sum() + " which is cheaper than the NSX Type S!" );
        }




        /// <summary>
        /// This action method displays an example of anonymous type
        /// </summary>
        /// <returns>information of example</returns>
        public IActionResult AnonymousType()
        {
            var v = new { Cost = 62051, Message = "The total cost of a fully loaded Acura RDX A-Spec Advanced is... $" };

            return Content(v.Message + v.Cost);

        }

        

    /// <summary>
    /// This action method displays an example of simple LINQ
    /// </summary>
    /// <returns>information of example</returns>
        public IActionResult SimpleLINQ()
        {
            var cars = new[]
            {
                new {Model =" Acura ILX A-Spec ", Price=31300 },
                new {Model =" Acura TLX Type S ", Price=52800 },
                new {Model =" Acura RDX A-Spec ", Price=47950 },
                new {Model =" Acura MDX Type S ", Price=66700 },
                new {Model =" Acura NSX Type S ", Price=169500 }

            };
            var carQuery =
               from c in cars
               select new { c.Model, c.Price };
            var model = "";
            foreach (var c in carQuery)
            {
                model += $"Make={c.Model}, Price={c.Price}\n";
            }
            return Content(model);
        }



        /// <summary>
        /// This action method displays an example of nullable types
        /// </summary>
        /// <returns>information of example</returns>
        public IActionResult NullableType()
        {
            var model = "";
            double? tlxTypeS = 4.7;
            if (tlxTypeS.HasValue)
            {
                model = "TLX Type S 0-60 = " + Convert.ToString(tlxTypeS.Value);
            }
            else
            {
                model = "TLX 0-60 = Undefined";
            }
            double? c = null;
            
            double nsxTypeS = c ?? 2.7;
            model += "\nNSX Type S 0-60 = " + Convert.ToString(nsxTypeS);

            return Content(model);
        }



        /// <summary>
        /// Displays the about page.
        /// </summary>
        /// <returns>view</returns>
        public IActionResult About()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        /// <summary>
        /// Displays an error page.
        /// </summary>
        /// <returns>formatted view of window</returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}