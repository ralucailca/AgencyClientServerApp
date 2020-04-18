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
    public class AgentDbRepository : IRepository<int, Agent>
    {
        private static readonly ILog log = LogManager.GetLogger("AgentDbRepository");

        public AgentDbRepository()
        {
            log.Info("Creating AgentDbRepository");
        }

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Agenti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No agent deleted!");
            }
        }

        public IEnumerable<Agent> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Agent> agenti = new List<Agent>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, user, password from Agenti";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int ida = dataR.GetInt32(0);
                        string user = dataR.GetString(1);
                        string password = dataR.GetString(2);
                        Agent agent = new Agent(ida, user, password);
                        agenti.Add(agent);
                    }
                }
            }

            return agenti;
        }

        public Agent findOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, user, password from Agenti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int ida = dataR.GetInt32(0);
                        string user = dataR.GetString(1);
                        string password = dataR.GetString(2);
                        Agent agent = new Agent(ida, user, password);
                        log.InfoFormat("Exiting findOne with value {0}", agent);
                        return agent;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void save(Agent entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Agenti  values (@id, @user, @password)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramUser = comm.CreateParameter();
                paramUser.ParameterName = "@user";
                paramUser.Value = entity.User;
                comm.Parameters.Add(paramUser);

                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@password";
                paramPass.Value = entity.Password;
                comm.Parameters.Add(paramPass);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No agent added !");
            }
        }

        public void update(int id, Agent entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Agenti set user=@user, password=@password where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramUser = comm.CreateParameter();
                paramUser.ParameterName = "@user";
                paramUser.Value = entity.User;
                comm.Parameters.Add(paramUser);

                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@password";
                paramPass.Value = entity.Password;
                comm.Parameters.Add(paramPass);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No agent modified !");
            }
        }
    }
}
