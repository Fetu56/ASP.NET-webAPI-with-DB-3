using Dohroz.LogicClasses;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Dohroz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ConsumptionController : Controller
    {
        SqlConnection connection;

        public ConsumptionController()
        {
            connection = ConnectionSigleton.Instance.connection;
        }
        [HttpGet(Name = "GetCons")]
        public IActionResult GetCons()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Cons];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpGet(Name = "GetConsByDate")]
        public IActionResult GetConsByDate()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Cons] ORDER BY [adddate];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpGet(Name = "GetConsByCat")]
        public IActionResult GetConsByCat()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Cons] ORDER BY [cat_id];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpGet(Name = "GetConsByMoney")]
        public IActionResult GetConsByMoney()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Cons] ORDER BY [moneycons];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpPost(Name = "AddCons")]
        public IActionResult AddCons(decimal moneycons, int cat_id, string desc = "_")
        {
            try
            {
                ArgumentNullException.ThrowIfNull(moneycons);
                ArgumentNullException.ThrowIfNull(cat_id);
                SqlCommand cmd = new SqlCommand($"INSERT INTO [Cons] VALUES('{desc}', {moneycons}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}',{cat_id});", connection);
                return Ok("Rows affected: " + cmd.ExecuteNonQuery());
            }
            catch (Exception) { }
            return Ok(false);
        }

        [HttpDelete(Name = "DeleteCons")]
        public IActionResult DeleteCons(int id)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(id);
                SqlCommand cmd = new SqlCommand($"DELETE FROM [Cons] WHERE [id] = '{id}';", connection);
                return Ok("Rows affected: " + cmd.ExecuteNonQuery());
            }
            catch (Exception) { }
            return Ok(false);
        }
    }
}
