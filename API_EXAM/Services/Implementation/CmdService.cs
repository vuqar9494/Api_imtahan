
using API_EXAM.Interface;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data.SqlClient;

namespace API_EXAM.Implementation
{
    public class CmdService : ICmdService
    {

        public static object GetDataValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }

            return value;
        }

/*        public SqlCommand GetStudentExamVM(SqlCommand cmd, bool isSkip, FilterStudentExamVM model)
        {

            cmd.Parameters.AddWithValue("@CourseId", GetDataValue(model.CourseId));
            cmd.Parameters.AddWithValue("@UserId", GetDataValue(model.UserId));
            cmd.Parameters.AddWithValue("@User", GetDataValue("%" + model.User + "%"));
            cmd.Parameters.AddWithValue("@StatusId", GetDataValue(model.StatusId));
            cmd.Parameters.AddWithValue("@FromDate", GetDataValue(model.FromDate));
            cmd.Parameters.AddWithValue("@ToDate", GetDataValue(model.ToDate));




            if (!isSkip)
            {

                cmd.Parameters.AddWithValue("skip", GetDataValue(model.skip));
                cmd.Parameters.AddWithValue("limit", GetDataValue(model.limit));
            }


            return cmd;
        }*/




    }
}
