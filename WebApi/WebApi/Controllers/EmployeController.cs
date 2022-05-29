using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApi.Models;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public EmployeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select EmployeId, EmployeName, Department, 

            convert(varchar(10),DateOfJoining,120) as DateOfJoining, PhotoFileName from dbo.Employe";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myreader;

            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand cmd = new SqlCommand(query, mycon))
                {
                    myreader = cmd.ExecuteReader();
                    table.Load(myreader); ;

                    myreader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);

        }

        [HttpPost]

        public JsonResult Post(Employee emp)
        {
            string query = @"insert into dbo.Employe 
               (EmployeName, DateOfJoining, Department, PhotoFileName)
             values
              ('" + emp.EmployeName + @"'
              ,'" + emp.DateOfJoining + @"'
              ,'" + emp.Department + @"'
              ,'" + emp.PhotoFileName + @"')";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myreader;

            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand cmd = new SqlCommand(query, mycon))
                {
                    myreader = cmd.ExecuteReader();
                    table.Load(myreader); ;

                    myreader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Succesfully");
        }

        [HttpPut]

        public JsonResult Put(Employee emp)
        {
            string query = @"update dbo.Employe set 
            EmployeName ='" + emp.EmployeName + @"',
            Department = '" + emp.Department + @"',
            DateOfJoining = '" + emp.DateOfJoining + @"'
            where EmployeId = '" + emp.EmployeeId + @"'
         
            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myreader;

            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand cmd = new SqlCommand(query, mycon))
                {
                    myreader = cmd.ExecuteReader();
                    table.Load(myreader); ;

                    myreader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Update Succesfully");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            string query = @"delete from dbo.Employe where 
            EmployeId ='" + id + @"'      
            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myreader;

            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand cmd = new SqlCommand(query, mycon))
                {
                    myreader = cmd.ExecuteReader();
                    table.Load(myreader); ;

                    myreader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Delete Succesfully");
        }

        [Route("SaveFile")]
        [HttpPost]

        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("success");
            }
        }

        [Route("GetAllDepartmentnames")]
        public JsonResult GetAlldepartmentnames()
        {
            string query = @"
                        select DepartmentName from dbo.Department";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myreader;

            using (SqlConnection mycon = new SqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (SqlCommand cmd = new SqlCommand(query, mycon))
                {
                    myreader = cmd.ExecuteReader();
                    table.Load(myreader); ;

                    myreader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
