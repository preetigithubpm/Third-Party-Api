using Microsoft.Data.SqlClient;
using System.Data;
using task29August.RequestModel;

namespace task29August.repository
{
    public class CountRepository:ICount
    {
        public List<GetCountDobChartModel> getPatientCount()
        {
            List<GetCountDobChartModel> result = new List<GetCountDobChartModel>();

            var builder = WebApplication.CreateBuilder();
            string constr = builder.Configuration.GetConnectionString("AppConnectionString");
            SqlConnection con = new SqlConnection(constr);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            using (var command = new SqlCommand("getcount1", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new GetCountDobChartModel
                        {
                            Dob = (DateTime)reader["DOB"],
                            Count = (int)reader["count"]
                        });
                    }
                }

            }

            return result;
        }
    }
}
