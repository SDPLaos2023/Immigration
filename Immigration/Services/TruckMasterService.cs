using Immigration.Entity;
using Immigration.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Immigration.Services
{
    public class TruckMasterService
    {
        private SDP_Immigration_DBContext _context = new SDP_Immigration_DBContext();
        public string TruckMasterInsert(TruckMasterModel _TruckMaster,string Mode)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_TRUCK_MASTER_DATA_INSERT_UPDATE_DELETE";
                command.Parameters.Add(new SqlParameter("@TRUCK_LICENCE_PLATE_NO", _TruckMaster.Truck_No));
                command.Parameters.Add(new SqlParameter("@TRUCK_TYPE", _TruckMaster.Truck_Type));
                command.Parameters.Add(new SqlParameter("@COMPANY_NAME", _TruckMaster.Truck_Name));
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
        
        public DataTable TruckMasterSelect(long ID)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_TRUCK_MASTER_DATA_SELECT_BY_ID";
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
