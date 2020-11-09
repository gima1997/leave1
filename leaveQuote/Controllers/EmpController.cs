using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using leaveQuote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace leaveQuote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private IConfiguration configuration;

        public EmpController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        private MySqlConnection GetConnection()
        {
            string _Connstr = configuration.GetValue<string>("AppSettings:myConnString");
            return new MySqlConnection(_Connstr);
        }

       
        //https://localhost:5001/api/Emp/GetAllEmployee
        [HttpGet]
        [Route("GetAllEmployee")]
        public List<EmpModel> GetAllEmployee()
        {
            cls_Logger obj = new cls_Logger(configuration);
            obj.LogError("Entering GetAllEmployee()");

            List<EmpModel> objList = new List<EmpModel>();

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    obj.LogError("DB Connection Opened");
                    MySqlCommand cmd = new MySqlCommand("GetAllEmp", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        obj.LogError("Data Read...");
                        while (dr.Read())
                        {
                            objList.Add(new EmpModel()
                            {
                                empId = Convert.ToInt32(dr["empId"]),
                                Name = dr["Name"].ToString(),
                                Casual = Convert.ToInt32(dr["Casual"]),
                                Annual = Convert.ToInt32(dr["Annual"]),
                                Medical = Convert.ToInt32(dr["Medical"]),
                                Home = Convert.ToInt32(dr["Home"]),
                                Special = Convert.ToInt32(dr["Special"]),
                                Type = dr["Type"].ToString(),
                            });
                        }
                        obj.LogError("Data Read Completed.");
                    }
                    return objList;
                }

            }
            catch (Exception ex)
            {
                obj.LogError("Error in GetAllEmployee():" + ex.Message);
                throw ex;
            }

        }

    }
}
