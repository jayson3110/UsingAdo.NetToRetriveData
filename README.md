# UsingAdo.NetToRetriveData

Another way to retrive data in ado.net



    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("data source=JAYSON\\SQLEXPRESS; database=AOMG; integrated security=SSPI");
        public ActionResult Index()
        {
            var artist = from e in GetListArtist()
                         select e;

            return View(artist);
        }


        [NonAction]
        public List<Artist> GetListArtist()
        {

            var model = new List<Artist>();
            SqlCommand cmd = new SqlCommand("select * from AOMG_Artist");
            cmd.Connection = con;
            con.Open();

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


            return model;
        }



    }


