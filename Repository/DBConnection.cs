using MySql.Data.MySqlClient;

namespace Simplon.Data.Repository
{   
    class DBConnection
    {
        public static MySqlConnection GetConnection(){
            
            return new MySqlConnection("server=localhost;uid=simplon;pwd=@zertY1234;database=dataLayer");
        }
    }
}