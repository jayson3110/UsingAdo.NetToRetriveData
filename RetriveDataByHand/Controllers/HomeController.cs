using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using RetriveDataByHand.Models;

namespace RetriveDataByHand.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI");
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(Account account)
        {
            string status = "";
            // Creating Connection  

            // Executing select command  
            using (SqlCommand cmd = new SqlCommand("select * from Users where username='" + account.username + "' and password='" + account.password + "'"))
            {
                cmd.Connection = con;

                con.Open();
                // Retrieving Record from datasource  
                SqlDataReader sdr = cmd.ExecuteReader();
                // Checking  Records  
                if (sdr.Read())
                {
                    con.Close();
                    status += "Sucesss";
                }
                else
                {
                    con.Close();
                    status += "Error";
                }

            }
         
            return RedirectToAction("Artist");


        }

        public ActionResult Artist()
        {
            string status = "";
            var model = new List<Artist>();
            using (SqlCommand cmd = new SqlCommand("select * from AOMG_Artist"))
            {
                cmd.Connection = con;

                con.Open();
                // Retrieving Record from datasource  
                SqlDataReader sdr = cmd.ExecuteReader();
                // Reading and Iterating Records  
                while (sdr.Read())
                {
                    var artist = new Artist();
                    artist.Artist_Name += sdr["Artist_Name"];
                    artist.Artist_role += sdr["Artist_role"];
                    artist.Artist_contact += sdr["Artist_contact"];
                    model.Add(artist);


                }
              

              


            }
            return View(model);

        }
    }
}