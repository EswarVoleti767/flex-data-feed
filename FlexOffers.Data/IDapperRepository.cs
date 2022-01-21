using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDataFeed.Data
{
    public interface IDapperRepository
    {
        T GetById<T>(int id, string sqlQuery);
        List<T> GetAll<T>(string query);
        List<int> Query(string query);
        List<T> GetAllWithParams<T>(string query, IEnumerable<int> id);
        T ExecuteProcSingle<T>(string procName, object param);
        int Add<T>(T entity, string sqlQuery);
        int Update<T>(T entity, string sqlQuery);
        int Delete(int id, string sqlQuery);
        List<T> ExecuteProcedure<T>(string procName, object param);
        List<T> ExecuteProcedure<T>(string connectionSring, string procName, object param);
        T QuerySingle<T>(string sqlQuery);
    }
}
