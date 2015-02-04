using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using ServiceStack.ServiceInterface;


namespace DokterBerre.Library.Db
{
    

    public class Repository
    {
        public string ConnectionString { get; set; }

        public Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Setup()
        {
            OrmLiteConfig.DialectProvider = MySqlDialectProvider.Instance;

            using (IDbConnection db =
                ConnectionString.OpenDbConnection())
            {
                db.DropTable<Dokter>();
                db.CreateTable<Dokter>();
                db.DeleteAll<Dokter>();

                List<Dokter> Dokters = new List<Dokter>();
                Dokters.Add(new Dokter()
                {
                    Naam = "Dr Drake Ramoray",
                    Printer = "Brother HL-4570CDW series",
                });
                

                db.InsertAll(Dokters);
            }
        }

        public IEnumerable<Dokter> GetAllDokters()
        {
            using (IDbConnection db =
                ConnectionString.OpenDbConnection())
            {
                return db.Select<Dokter>();
            }
        } 
    }
}
