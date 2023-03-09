using Immigration.Entity;
using Immigration.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Immigration.Services
{
    public class PassportService
    {
        private SDP_Immigration_DBContext _context = new SDP_Immigration_DBContext();
        public string PassportRegisterWithMode(PassportRegisterModel _passportRegister, string Mode)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_PASSPORT_REGISTER_INSERT";
                command.Parameters.Add(new SqlParameter("@Surname", _passportRegister.Surname));
                command.Parameters.Add(new SqlParameter("@Given_name", _passportRegister.GivenName));
                command.Parameters.Add(new SqlParameter("@Birth_of_date", Convert.ToDateTime(_passportRegister.BirthOfDate)));
                command.Parameters.Add(new SqlParameter("@Sex", _passportRegister.Sex));
                command.Parameters.Add(new SqlParameter("@Country", _passportRegister.Country));
                command.Parameters.Add(new SqlParameter("@Birth_Country", _passportRegister.BirthCountry));
                command.Parameters.Add(new SqlParameter("@Document_No", _passportRegister.DocumentNo));
                command.Parameters.Add(new SqlParameter("@Mode", Mode));
                command.CommandType = CommandType.StoredProcedure;
                _context.Database.OpenConnection();
                var result = command.ExecuteScalar();
                return "Success";
            }
            catch(Exception ex)
            {
                return "Fail";
            }
        }

        public DataTable PassportRegisterSelect(long ID)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_PASSPORT_REGISTER_SELECT_BY_ID";
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
