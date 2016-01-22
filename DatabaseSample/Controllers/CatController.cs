using DatabaseSample.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseSample.Controllers
{
    public class CatController : Controller
    {
        SqlConnection connection;
        private List<Cat> catList;

        public CatController()
        {
            catList = new List<Cat>();

            connection = new SqlConnection("Data Source=HYPERION;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=ASP_SQL_SAMPLE;");

            connection.Open();
        }

        // GET: Cat
        public ActionResult Index()
        {
            using (var query = new SqlCommand("SELECT * FROM Pets", connection))
            {
                using (var reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cat = new Cat
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Type = (string)reader["PetType"],
                            OwnerId = (int)reader["OwnerId"]
                        };

                        catList.Add(cat);
                    }
                }
            }

            return View(catList);
        }

        //GET: Cat
        public ActionResult Details(int id)
        {
            Cat cat;
            using (var query = new SqlCommand(String.Format("SELECT * FROM Pets WHERE Pets.Id = {0}", id), connection))
            {
                using (var reader = query.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cat = new Cat
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Type = (string)reader["PetType"],
                            OwnerId = (int)reader["OwnerId"]
                        };
                    }
                    else
                    {
                        return this.HttpNotFound();
                    }
                }
            }
            return View(cat);
        }

        //GET: Cat
        public ActionResult Remove(int id)
        {
            using (var query = new SqlCommand("DELETE FROM Pets WHERE Pets.Id = @param", connection))
            {
                query.Parameters.AddWithValue("@param", id);
                query.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        //GET: Cat
        public ActionResult Add()
        {
            return View();
        }

        //POST: Cat
        [HttpPost]
        public ActionResult Add(Cat cat)
        {
            using (var command = new SqlCommand(string.Format("INSERT INTO Pets (Name, PetType, OwnerId) VALUES (@name, @type, 1)"), connection))
            {
                command.Parameters.AddWithValue("@name", cat.Name);
                command.Parameters.AddWithValue("@type", cat.Type);
                command.ExecuteNonQuery();
            }

            return RedirectToAction("Details", new { Id = cat.Id });
        }
    }
}