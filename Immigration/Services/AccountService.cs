using Immigration.Entity;
using Immigration.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Immigration.Services
{
    public class AccountService
    {
        private SDP_Immigration_DBContext _context = new SDP_Immigration_DBContext();
        public DataTable SystemUserSelect(AccountModel accountModel)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_SYSTEM_USER_SELECT";
                command.Parameters.Add(new SqlParameter("@Username", accountModel.UserName));
                command.Parameters.Add(new SqlParameter("@Password", accountModel.Password));
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
