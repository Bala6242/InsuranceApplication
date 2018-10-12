using Insurance.Data.Login.Contracts;
using Insurance.Infrastructure.Base;
using System.Data;
using System.Data.SqlClient;

namespace Insurance.Data.Login.Repositories
{
    class LoginRepository : BaseRepository, ILoginRepository
    {
        static string AzureSqlConnectionDev = "";
        void ILoginRepository.GetLoginDetails(string name)
        {
            
            using (IDbConnection dbconnection = new SqlConnection(AzureSqlConnectionDev))
            {
                //DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@CityName", );

                //var queryResult = dbconnection.Query<BusinessSearchResultV2Dto>("dbo.prcname", parameters, commandType: CommandType.StoredProcedure);
                //if (queryResult != null)
                //{
                //}
                //dbconnection?.Close();
            }
        }
    }
}
