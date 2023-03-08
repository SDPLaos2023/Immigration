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
        public string BkackListInsert(TruckMasterModel _TruckMaster)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_Bkack_List_DATA_INSERT";
                command.Parameters.Add(new SqlParameter("@TRUCK_LICENCE_PLATE_NO", _TruckMaster.Truck_No));
                command.Parameters.Add(new SqlParameter("@TRUCK_TYPE", _TruckMaster.Truck_Type));
                command.Parameters.Add(new SqlParameter("@COMPANY_NAME", _TruckMaster.Truck_Name));

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

        public DataTable BkackListSelect(string TruckLicencePlateNo)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_TRUCK_MASTER_DATA_SELECT_BY_TRUCK_NO";
                command.Parameters.Add(new SqlParameter("@TRUCK_LICENCE_PLATE_NO", TruckLicencePlateNo));
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
