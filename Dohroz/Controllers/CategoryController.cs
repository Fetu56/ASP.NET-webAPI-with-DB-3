using Dohroz.LogicClasses;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Dohroz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        SqlConnection connection;

        public CategoryController()
        {
            connection = ConnectionSigleton.Instance.connection;
        }
        [HttpGet(Name = "GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Category];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpPost(Name = "AddCategory")]
        public IActionResult AddCategory(string name)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(name);
                SqlCommand cmd = new SqlCommand($"INSERT INTO [Category] VALUES('{name}');", connection);
                return Ok("Rows affected: "+cmd.ExecuteNonQuery());
            }
            catch (Exception) { }
            return Ok(false);
        }

        [HttpDelete(Name = "DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(id);
                SqlCommand cmd = new SqlCommand($"DELETE FROM [Category] WHERE [id] = '{id}';", connection);
                return Ok("Rows affected: " + cmd.ExecuteNonQuery());
            }
            catch (Exception) { }
            return Ok(false);
        }
    }
}