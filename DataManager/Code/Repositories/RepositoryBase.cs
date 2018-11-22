using System.Data.SqlClient;

namespace DataManager.Code.Base
{
    public abstract class RepositoryBase
    {
        public abstract void FillObject(object entity, SqlDataReader reader);

    }
}
