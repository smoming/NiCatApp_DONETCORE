using System.Linq;
using System.Data;
using System.Collections.Generic;
using NiCatApp_DONETCORE.Models;
using NiCatApp_DONETCORE.Repositories;
using Dapper;

namespace NiCatApp_DONETCORE.Services
{
    public class NationService
    {
        private DbConnection _conn;
        private readonly string SP_LIST = "SP_NATION_LIST";
        private readonly string SP_GET = "SP_NATION_GET";
        private readonly string SP_ADD = "SP_NATION_ADD";
        private readonly string SP_UPDATE = "SP_NATION_UPDATE";
        private readonly string SP_DELETE = "SP_NATION_DELETE";

        public NationService(DbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<NationDTO> list()
        {
            using (var res = new BaseRepository<NationDTO>(_conn))
            {
                return res.doQuery(SP_LIST);
            }
        }

        public NationDTO get(string id)
        {
            var p = new DynamicParameters();
            p.Add("i_ID", id, DbType.String, ParameterDirection.Input);
            using (var res = new BaseRepository<NationDTO>(_conn))
            {
                return res.doQuery(SP_GET, p).FirstOrDefault();
            }
        }

        public void add(NationDTO item)
        {
            using (var res = new BaseRepository<NationDTO>(_conn))
            {
                res.doExecute(SP_ADD, toSqlParams(item));
            }
        }

        public void update(NationDTO item)
        {
            using (var res = new BaseRepository<NationDTO>(_conn))
            {
                res.doExecute(SP_UPDATE, toSqlParams(item));
            }
        }

        public void delete(string id)
        {
            using (var res = new BaseRepository<NationDTO>(_conn))
            {
                res.doExecute(SP_DELETE, toSqlParams(get(id)));
            }
        }

        private DynamicParameters toSqlParams(NationDTO item)
        {
            var p = new DynamicParameters();
            p.Add("i_ID", item.ID, DbType.String, ParameterDirection.Input);
            p.Add("i_NAME", item.NAME, DbType.String, ParameterDirection.Input);
            return p;
        }
    }
}