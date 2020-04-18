using log4net;
using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence
{
    public class ClientDbRepository : IRepository<int, Client>
    {
        public static readonly ILog log = LogManager.GetLogger("ClientDbRepository");

        public ClientDbRepository()
        {
            log.Info("Creating ClientDbRepository...");
        }
        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Clienti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No client deleted!");
            }
        }

        public IEnumerable<Client> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Client> clienti = new List<Client>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nume, telefon from Clienti";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idc = dataR.GetInt32(0);
                        string nume = dataR.GetString(1);
                        string telefon = dataR.GetString(2);
                        Client c = new Client(idc, nume, telefon);
                        clienti.Add(c);
                    }
                }
            }

            return clienti;
        }

        public Client findOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nume, telefon from Clienti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idc = dataR.GetInt32(0);
                        string nume = dataR.GetString(1);
                        string telefon = dataR.GetString(2);
                        Client c = new Client(idc, nume, telefon);
                        log.InfoFormat("Exiting findOne with value {0}", c);
                        return c;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void save(Client entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Clienti values (@id, @nume, @telefon)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramTel = comm.CreateParameter();
                paramTel.ParameterName = "@telefon";
                paramTel.Value = entity.Telefon;
                comm.Parameters.Add(paramTel);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No client added !");
            }
        }

        public void update(int id, Client entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Clienti set nume=@nume, telefon=@telefon where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramTel = comm.CreateParameter();
                paramTel.ParameterName = "@telefon";
                paramTel.Value = entity.Telefon;
                comm.Parameters.Add(paramTel);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No client modified !");
            }
        }
    }
}
