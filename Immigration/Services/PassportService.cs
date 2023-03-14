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
                var Id = String.Empty;
                if (Mode == "INSERT") Id = "0";
                else Id = _passportRegister.Id.ToString();
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_PASSPORT_REGISTER_INSERT";
                command.Parameters.Add(new SqlParameter("@ID", Convert.ToInt64(Id)));
                command.Parameters.Add(new SqlParameter("@Name", _passportRegister.Name));
                command.Parameters.Add(new SqlParameter("@Surname", _passportRegister.Surname));
                command.Parameters.Add(new SqlParameter("@Birth_of_date", Convert.ToDateTime(_passportRegister.BirthOfDate)));
                command.Parameters.Add(new SqlParameter("@Sex", _passportRegister.Sex));
                command.Parameters.Add(new SqlParameter("@Country", _passportRegister.Country));
                command.Parameters.Add(new SqlParameter("@Birth_Country", _passportRegister.BirthCountry));
                command.Parameters.Add(new SqlParameter("@Document_No", _passportRegister.DocumentNo));
                command.Parameters.Add(new SqlParameter("@Mode", Mode));
                //command.Parameters.Add(new SqlParameter("@ImagePath", _passportRegister.ImagePath));
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

        public DataTable PassportRegisterSelect(long _ID, string _Mode)
        {
            try
            {
                var command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = "SP_PASSPORT_REGISTER_SELECT_BY_ID";
                command.Parameters.Add(new SqlParameter("@ID", _ID));
                command.Parameters.Add(new SqlParameter("@Mode", _Mode));
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

        public PassportRegisterModel PassportSetModel(DataTable _passportData)
        {
            var model = new PassportRegisterModel();
            foreach (DataRow _item in _passportData.Rows)
            {
                model.Id = Convert.ToInt64(_item["Id"]);
                model.Name = _item["Name"].ToString();
                model.Surname = _item["Surname"].ToString();
                model.BirthOfDate = Convert.ToDateTime(_item["Birth_of_date"]).ToString("yyyy-MM-dd");
                model.Sex = _item["Sex"].ToString();
                model.Country = _item["Country"].ToString();
                model.BirthCountry = _item["Birth_Country"].ToString();
                model.DocumentNo = Convert.ToInt32(_item["Document_No"]);
            }
            return model;
        }

        public PassportDataModel PassportSetListModel(DataTable _passportData)
        {
            var model = new PassportDataModel();
            foreach (DataRow _item in _passportData.Rows)
            {
                model.Id.Add(Convert.ToInt64(_item["Id"]));
                model.Name.Add(_item["Name"].ToString());
                model.Surname.Add(_item["Surname"].ToString());
                model.BirthOfDate.Add(Convert.ToDateTime(_item["Birth_of_date"]).ToString("dd/MM/yyyy"));
                if(_item["Sex"].ToString() == "M") model.Sex.Add("ชาย");
                else model.Sex.Add("หญิง");
                model.Country.Add(_item["Country"].ToString());
                model.BirthCountry.Add(_item["Birth_Country"].ToString());
                model.DocumentNo.Add(Convert.ToInt32(_item["Document_No"]));
            }
            return model;
        }
    }
}
