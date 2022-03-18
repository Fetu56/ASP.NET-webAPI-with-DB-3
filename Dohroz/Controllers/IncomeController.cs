using Dohroz.LogicClasses;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Dohroz.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class IncomeController : Controller
    {
        SqlConnection connection;

        public IncomeController()
        {
            connection = ConnectionSigleton.Instance.connection;
        }
        [HttpGet(Name = "GetInc")]
        public IActionResult GetInc()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Inc];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpGet(Name = "GetIncByDate")]
        public IActionResult GetIncByDate()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Inc] ORDER BY [adddate];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpGet(Name = "GetIncByCat")]
        public IActionResult GetIncByCat()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Inc] ORDER BY [cat_id];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpGet(Name = "GetIncByMoney")]
        public IActionResult GetIncByMoney()
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM [Inc] ORDER BY [moneyinc];", connection);
                return Ok(cmd.ExecuteToJson());
            }
            catch (Exception) { }
            return Ok(null);
        }
        [HttpPost(Name = "AddInc")]
        public IActionResult AddInc(decimal moneyinc, int cat_id, string desc = "_")
        {
            try
            {
                ArgumentNullException.ThrowIfNull(moneyinc);
                ArgumentNullException.ThrowIfNull(cat_id);
                SqlCommand cmd = new SqlCommand($"INSERT INTO [Inc] VALUES('{desc}', {moneyinc}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}',{cat_id});", connection);
                return Ok("Rows affected: " + cmd.ExecuteNonQuery());
            }
            catch (Exception) { }
            return Ok(false);
        }

        [HttpDelete(Name = "DeleteInc")]
        public IActionResult DeleteInc(int id)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(id);
                SqlCommand cmd = new SqlCommand($"DELETE FROM [Inc] WHERE [id] = '{id}';", connection);
                return Ok("Rows affected: " + cmd.ExecuteNonQuery());
            }
            catch (Exception) { }
            return Ok(false);
        }
    }
}
