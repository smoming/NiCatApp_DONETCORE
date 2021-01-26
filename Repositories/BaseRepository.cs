using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace NiCatApp_DONETCORE.Repositories {
    public class BaseRepository<T> : IDisposable {
        private MySqlConnection _conn;
        public BaseRepository (DbConnection conn) {
            _conn = new MySqlConnection (conn.Connection.ConnectionString);
        }

        public IEnumerable<T> doQuery (string sp, DynamicParameters spparam = null) {
            return _conn.Query<T> (sql: sp, param: spparam, commandType: CommandType.StoredProcedure);
        }

        public void doExecute (string sp, DynamicParameters spparam = null) {
            _conn.Execute (sql: sp, param: spparam, commandType: CommandType.StoredProcedure);
        }

        public void Dispose () {
            if (_conn != null)
                _conn.Dispose ();
        }
    }
}