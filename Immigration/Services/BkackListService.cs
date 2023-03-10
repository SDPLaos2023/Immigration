using Immigration.Entity;
using Immigration.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Immigration.Services
{
    public class BkackListService
    {
        private SDP_Immigration_DBContext _context = new SDP_Immigration_DBContext();
        public string BkackListInsert(BkackListModels _BkackList, string Mode)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_BLACK_LIST_REGISTER_INSERT_EDIT_DELETE";
                command.Parameters.Add(new SqlParameter("@Surname", _BkackList.Surname));
                command.Parameters.Add(new SqlParameter("@Given_name", _BkackList.Given_name));
                command.Parameters.Add(new SqlParameter("@Birth_of_dat", _BkackList.Birth_of_date));
                command.Parameters.Add(new SqlParameter("@Sex", _BkackList.Sex));
                command.Parameters.Add(new SqlParameter("@Country", _BkackList.Country));
                command.Parameters.Add(new SqlParameter("@Birth_Countryt", _BkackList.Birth_Country));
                command.Parameters.Add(new SqlParameter("@Document_No", _BkackList.Document_No));
                command.Parameters.Add(new SqlParameter("@Remarks", _BkackList.Remarks));
                command.Parameters.Add(new SqlParameter("@Mode", Mode));
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
        public string BkackListUPDATE(BkackListModels _BkackList, string Mode)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_BLACK_LIST_REGISTER_INSERT_EDIT_DELETE";
                command.Parameters.Add(new SqlParameter("@Surname", _BkackList.Surname));
                command.Parameters.Add(new SqlParameter("@Given_name", _BkackList.Given_name));
                command.Parameters.Add(new SqlParameter("@Birth_of_dat", _BkackList.Birth_of_date));
                command.Parameters.Add(new SqlParameter("@Sex", _BkackList.Sex));
                command.Parameters.Add(new SqlParameter("@Country", _BkackList.Country));
                command.Parameters.Add(new SqlParameter("@Birth_Countryt", _BkackList.Birth_Country));
                command.Parameters.Add(new SqlParameter("@Document_No", _BkackList.Document_No));
                command.Parameters.Add(new SqlParameter("@Remarks", _BkackList.Remarks));
                command.Parameters.Add(new SqlParameter("@ID", _BkackList.Id));
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

        public DataTable BkackListSelect(long _ID)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_BLACK_LIST_REGISTER_SELECT_BY_ID";
                command.Parameters.Add(new SqlParameter("@ID", _ID));
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
