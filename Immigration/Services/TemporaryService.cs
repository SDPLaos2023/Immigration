using Immigration.Entity;
using Immigration.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Immigration.Services
{
    public class TemporaryService
    {
        private SDP_Immigration_DBContext _context = new SDP_Immigration_DBContext();
        public string TemporaryBorderPassInsert(TemporaryBorderModel _temporaryBorder)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_TEMPORARY_BORDER_PASS_INSERT";
                command.Parameters.Add(new SqlParameter("@Surname", _temporaryBorder.Surname));
                command.Parameters.Add(new SqlParameter("@Given_name", _temporaryBorder.GivenName));
                command.Parameters.Add(new SqlParameter("@Birth_of_date", Convert.ToDateTime(_temporaryBorder.BirthOfDate)));
                command.Parameters.Add(new SqlParameter("@Sex", _temporaryBorder.Sex));
                command.Parameters.Add(new SqlParameter("@Country", _temporaryBorder.Country));
                command.Parameters.Add(new SqlParameter("@Birth_Country", _temporaryBorder.BirthCountry));
                command.Parameters.Add(new SqlParameter("@Document_No", _temporaryBorder.DocumentNo));
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

        public DataTable TemporaryBorderPassSelect(long ID)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_TEMPORARY_BORDER_PASS_SELECT_BY_ID";
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
