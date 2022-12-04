using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using TP3.Models;

namespace TP3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                SQLiteConnection dbCon = new SQLiteConnection(@"Data Source=C:\Users\ThinkPad\Documents\web\c sharp\TP3\2022 GL3 .NET Framework TP3 - SQLite database.db");
                dbCon.Open();
                using (dbCon)
                {
                    SQLiteCommand cmd = new SQLiteCommand(
                        " SELECT * FROM personal_info ",
                        dbCon);
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader[0];
                            string firstname = (string)reader[1];
                            string lastname = (string)reader["last_name"];
                            string email = (string)reader["email"];
                            string image = (string)reader["image"];
                            string country = (string)reader["country"];
                            Debug.WriteLine("{0} {1} {2} {3} {4} {5}  ", id, firstname, lastname, email, country, image);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught:" + ex.Message);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}