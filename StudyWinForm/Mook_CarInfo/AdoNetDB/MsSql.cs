using System.Data;
using System.Data.SqlClient;

namespace AdoNetDB
{
    // AppConfiguration 프로젝트의 ConfigurationMgr 에서 사용되게 됨.
    // AppConfiguration 프로젝트에서  
    public class MsSql : IDatabase
    { 
        public string ConnectionString { get; set; }
        public IDbConnection Connection { get; set; }

        public MsSql(string connectgion_string)
        {
            // 데이터베이스 접속 문자열
            ConnectionString = connectgion_string;
            // 접속 문자열을 사용하여 데이터베이스 접속 커넥션 => SqlConnection
            Connection = new SqlConnection(ConnectionString);
        }
    }
}
