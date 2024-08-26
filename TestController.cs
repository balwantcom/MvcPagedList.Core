using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class TestController : Controller
    {
       public string con = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TestModel obj)
        {

            if (ModelState.IsValid)
            {
                // string con = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
                SqlConnection conn = new SqlConnection(con.ToString());
                SqlCommand cmd = new SqlCommand("insert into Test(Name,Address)Values(@name, @address)", conn);
                TestModel test = new TestModel();
                conn.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@name", obj.Name);
                cmd.Parameters.AddWithValue("@address", obj.Address);
                cmd.ExecuteNonQuery();
                conn.Close();
                return View();
            }
            return View();
        }


        public ActionResult ShowData()
        {
            using (SqlConnection connection = new SqlConnection(con.ToString()))
            {
                SqlCommand cmd = new SqlCommand("Select Name, Address from Test", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlDataReader s = cmd.ExecuteReader();
                List<TestModel> Lstobj = new List<TestModel>();
                while (s.Read())
                {
                    TestModel obj = new TestModel();
                    obj.Name = s["Name"].ToString();
                    obj.Address = s["Address"].ToString();
                    Lstobj.Add(obj);
                }
                return View(Lstobj);
            }
               
        }
    }
}