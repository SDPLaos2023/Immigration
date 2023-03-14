using Immigration.Entity;
using Immigration.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Immigration.Services
{
    public class BlackListService
    {
        private SDP_Immigration_DBContext _context = new SDP_Immigration_DBContext();
        public string BlackListInsert(BlackListModels _BlackList, string Mode)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_BLACK_LIST_REGISTER_INSERT_EDIT_DELETE";
                command.Parameters.Add(new SqlParameter("@ID", Convert.ToInt64("0")));
                command.Parameters.Add(new SqlParameter("@Surname", _BlackList.Surname));
                command.Parameters.Add(new SqlParameter("@Given_name", _BlackList.Given_name));
                command.Parameters.Add(new SqlParameter("@Birth_of_date", _BlackList.Birth_of_date+" "+"00:00:00"));
                command.Parameters.Add(new SqlParameter("@Sex", _BlackList.Sex));
                command.Parameters.Add(new SqlParameter("@Country", _BlackList.Country));
                command.Parameters.Add(new SqlParameter("@Birth_Country", _BlackList.Birth_Country));
                command.Parameters.Add(new SqlParameter("@Document_No", _BlackList.Document_No));
                command.Parameters.Add(new SqlParameter("@Remarks", "เพิ่มช่องหมายเหตุ"));
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
        public string BlackListUPDATE(BlackListModels _BlackList, string Mode)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_BLACK_LIST_REGISTER_INSERT_EDIT_DELETE";
                command.Parameters.Add(new SqlParameter("@Surname", _BlackList.Surname));
                command.Parameters.Add(new SqlParameter("@Given_name", _BlackList.Given_name));
                command.Parameters.Add(new SqlParameter("@Birth_of_dat", _BlackList.Birth_of_date));
                command.Parameters.Add(new SqlParameter("@Sex", _BlackList.Sex));
                command.Parameters.Add(new SqlParameter("@Country", _BlackList.Country));
                command.Parameters.Add(new SqlParameter("@Birth_Country", _BlackList.Birth_Country));
                command.Parameters.Add(new SqlParameter("@Document_No", _BlackList.Document_No));
                command.Parameters.Add(new SqlParameter("@Remarks", _BlackList.Remarks));
                command.Parameters.Add(new SqlParameter("@ID", _BlackList.Id));
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

        public DataTable BlackListSelect(long _ID)
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
