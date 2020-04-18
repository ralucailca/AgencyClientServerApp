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
    public class RezervareDbRepository : IRepository<IdRezervare, Rezervare>
    {
        private static readonly ILog log = LogManager.GetLogger("RezervareDbRepository");

        public RezervareDbRepository()
        {
            log.Info("Creating RezervareDbRepository");
        }

        public void delete(IdRezervare id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Rezervari where idExcursie=@idE and idClient=@idC";
                IDbDataParameter paramIdE = comm.CreateParameter();
                paramIdE.ParameterName = "@idE";
                paramIdE.Value = id.IdExcursie;
                comm.Parameters.Add(paramIdE);
                IDbDataParameter paramIdC = comm.CreateParameter();
                paramIdC.ParameterName = "@idC";
                paramIdC.Value = id.IdClient;
                comm.Parameters.Add(paramIdC);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No rezervare deleted!");
            }
        }

        public IEnumerable<Rezervare> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Rezervare> rezervari = new List<Rezervare>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select idExcursie, idClient, bilete from Rezervari";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int ide = dataR.GetInt32(0);
                        int idc = dataR.GetInt32(1);
                        int bilete = dataR.GetInt32(2);
                        IdRezervare id = new IdRezervare
                        {
                            IdExcursie = ide,
                            IdClient = idc
                        };
                        Rezervare rezervare = new Rezervare(id, bilete);
                        rezervari.Add(rezervare);
                    }
                }
            }

            return rezervari;
        }

        public Rezervare findOne(IdRezervare id)
        {
            log.InfoFormat("Entering findOne with value {0} + {1}", id.IdExcursie, id.IdClient);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select idExcursie, idClient, bilete from Rezervari where idExcursie=@idE and idClient=@idC";
                IDbDataParameter paramIdE = comm.CreateParameter();
                paramIdE.ParameterName = "@idE";
                paramIdE.Value = id.IdExcursie;
                comm.Parameters.Add(paramIdE);
                IDbDataParameter paramIdC = comm.CreateParameter();
                paramIdC.ParameterName = "@idC";
                paramIdC.Value = id.IdClient;
                comm.Parameters.Add(paramIdC);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int ide = dataR.GetInt32(0);
                        int idc = dataR.GetInt32(1);
                        int bilete = dataR.GetInt32(2);
                        IdRezervare idr = new IdRezervare
                        {
                            IdExcursie = ide,
                            IdClient = idc
                        };
                        Rezervare rezervare = new Rezervare(idr, bilete);
                        log.InfoFormat("Exiting findOne with value {0}", rezervare);
                        return rezervare;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void save(Rezervare entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Rezervari values (@idE, @idC, @bilete)";
                IdRezervare id = entity.Id;
                IDbDataParameter paramIdE = comm.CreateParameter();
                paramIdE.ParameterName = "@idE";
                paramIdE.Value = id.IdExcursie;
                comm.Parameters.Add(paramIdE);

                IDbDataParameter paramIdC = comm.CreateParameter();
                paramIdC.ParameterName = "@idC";
                paramIdC.Value = id.IdClient;
                comm.Parameters.Add(paramIdC);

                var paramBilete = comm.CreateParameter();
                paramBilete.ParameterName = "@bilete";
                paramBilete.Value = entity.Bilete;
                comm.Parameters.Add(paramBilete);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No rezervare added !");
            }
        }

        public void update(IdRezervare id, Rezervare entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Rezervari set bilete=@bilete where idExcursie=@idE and idClient=@idC";
                IDbDataParameter paramIdE = comm.CreateParameter();
                paramIdE.ParameterName = "@idE";
                paramIdE.Value = id.IdExcursie;
                comm.Parameters.Add(paramIdE);

                IDbDataParameter paramIdC = comm.CreateParameter();
                paramIdC.ParameterName = "@idC";
                paramIdC.Value = id.IdClient;
                comm.Parameters.Add(paramIdC);

                var paramBilete = comm.CreateParameter();
                paramBilete.ParameterName = "@bilete";
                paramBilete.Value = entity.Bilete;
                comm.Parameters.Add(paramBilete);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No rezervare modified !");
            }
        }
    }
}
