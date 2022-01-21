using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDataFeed.Data
{
    public class DapperContext
    {
        #region Constants
        private readonly string _connectionString;
        #endregion

        #region Constructor
        public DapperContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ProductSkuImport"].ConnectionString;
        }
        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Utlities
        //private readonly IConfiguration _configuration;
        //public DapperContext(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //    this._connectionString = _configuration.GetConnectionString("FlexOffersConnectionString");
        //}
        //public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        #endregion

        #region Methods
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        public IDbConnection CreateConnection(string connectionString) => new SqlConnection(connectionString);
        #endregion
    }
}
