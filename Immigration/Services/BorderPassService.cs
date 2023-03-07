using Immigration.Entity;
using Immigration.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Immigration.Services
{
    public class BorderPassService
    {
        private SDP_Immigration_DBContext _context = new SDP_Immigration_DBContext();
        public string BorderPassRegisterInsert(BorderPassModel _borderPassModel)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_BORDER_PASS_REGISTER_INSERT";
                command.Parameters.Add(new SqlParameter("@Surname", _borderPassModel.Surname));
                command.Parameters.Add(new SqlParameter("@Given_name", _borderPassModel.GivenName));
                command.Parameters.Add(new SqlParameter("@Birth_of_date", Convert.ToDateTime(_borderPassModel.BirthOfDate)));
                command.Parameters.Add(new SqlParameter("@Sex", _borderPassModel.Sex));
                command.Parameters.Add(new SqlParameter("@Country", _borderPassModel.Country));
                command.Parameters.Add(new SqlParameter("@Village", _borderPassModel.Village));
                command.Parameters.Add(new SqlParameter("@District", _borderPassModel.District));
                command.Parameters.Add(new SqlParameter("@Province", _borderPassModel.Province));
                command.Parameters.Add(new SqlParameter("@Document_No", _borderPassModel.DocumentNo));
                command.Parameters.Add(new SqlParameter("@Occupation", _borderPassModel.Occupation));
                command.CommandType = CommandType.StoredProcedure;
                _context.Database.OpenConnection();
                var result = command.ExecuteScalar();
                return "Success";
            }
            catch (Exception ex)
            {
                return "Fail";
            }
        }

        public DataTable BorderPassSelect(long ID)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_BORDER_PASS_REGISTER_SELECT_BY_ID";
                command.Parameters.Add(new SqlParameter("@ID", ID));
                command.CommandType = CommandType.StoredProcedure;
                _context.Database.OpenConnection();
                var result = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(result);
                return dt;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }
    }
}
