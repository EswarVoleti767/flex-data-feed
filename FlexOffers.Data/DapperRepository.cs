using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FlexDataFeed.Data
{
    public class DapperRepository : IDapperRepository
    {
        #region Constants
        private readonly string _connectionString = string.Empty;
        private readonly DapperContext _dbcontext;
        #endregion

        #region Constructor
        public DapperRepository(DapperContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        #endregion

        #region Utilities

        #endregion

        #region Methods
        public T GetById<T>(int id, string sqlQuery)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                return connection.QuerySingleOrDefault<T>(sqlQuery, new { Id = id });
            }
        }
        public int Add<T>(T entity, string query)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                return connection.Execute(query, entity);
            }
        }
        public int Update<T>(T entity, string sqlQuery)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                return connection.Execute(sqlQuery, entity);
            }
        }
        public int Delete(int id, string query)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                return connection.Execute(query, new { Id = id });
            }
        }
        public List<T> GetAll<T>(string query)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(query).ToList();
            }
        }
        public List<T> GetAllWithParams<T>(string query, IEnumerable<int> Id)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(query, new { Id }).ToList();
            }
        }
        public List<T> ExecuteProcedure<T>(string procName, object param)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                var result = connection.Query<T>(procName, param, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public List<T> ExecuteProcedure<T>(string connectionString,string procName, object param)
        {
            using (var connection = _dbcontext.CreateConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<T>(procName, param, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public T ExecuteProcSingle<T>(string procName, object param)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                var result = connection.QuerySingle<T>(procName, param, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public T QuerySingle<T>(string sqlQuery)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                return connection.QuerySingle<T>(sqlQuery);
            }
        }
        public List<int> Query(string query)
        {
            using (var connection = _dbcontext.CreateConnection())
            {
                connection.Open();
                return connection.Query<int>(query).ToList();
            }
        }
        #endregion

    }
}
