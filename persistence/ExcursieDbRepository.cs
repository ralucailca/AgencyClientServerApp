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
    public class ExcursieDbRepository : IRepository<int, Excursie>
    {
        public static readonly ILog log = LogManager.GetLogger("ExcursieDbRepository");

        public ExcursieDbRepository()
        {
            log.Info("Creating ExcursieDbRepository");
        }

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Excursii where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No excursie deleted!");
            }
        }

        public IEnumerable<Excursie> findAll()
        {

            IDbConnection con = DBUtils.getConnection();
            IList<Excursie> excursii = new List<Excursie>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, obiectiv, firma, oraPlecare, pret, locuri from Excursii";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int ida = dataR.GetInt32(0);
                        string obiectiv = dataR.GetString(1);
                        string firma = dataR.GetString(2);
                        int ora = dataR.GetInt32(3);
                        float pret = dataR.GetFloat(4);
                        int locuri = dataR.GetInt32(5);
                        Excursie e = new Excursie(ida, obiectiv, firma, ora, pret, locuri);
                        excursii.Add(e);

                    }
                }

            }

            return excursii;
        }

        public Excursie findOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, obiectiv, firma, oraPlecare, pret, locuri from Excursii where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int ida = dataR.GetInt32(0);
                        string obiectiv = dataR.GetString(1);
                        string firma = dataR.GetString(2);
                        int ora = dataR.GetInt32(3);
                        float pret = dataR.GetFloat(4);
                        int locuri = dataR.GetInt32(5);
                        Excursie e = new Excursie(ida, obiectiv, firma, ora, pret, locuri);
                        log.InfoFormat("Exiting findOne with value {0}", e);
                        return e;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void save(Excursie entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Excursii  values (@id, @obiectiv, @firma, @ora, @pret, @locuri)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramObv = comm.CreateParameter();
                paramObv.ParameterName = "@obiectiv";
                paramObv.Value = entity.Obiectiv;
                comm.Parameters.Add(paramObv);

                var paramFirma = comm.CreateParameter();
                paramFirma.ParameterName = "@firma";
                paramFirma.Value = entity.Firma;
                comm.Parameters.Add(paramFirma);

                var paramOra = comm.CreateParameter();
                paramOra.ParameterName = "@ora";
                paramOra.Value = entity.OraPlecare;
                comm.Parameters.Add(paramOra);

                var paramPret = comm.CreateParameter();
                paramPret.ParameterName = "@pret";
                paramPret.Value = entity.Pret;
                comm.Parameters.Add(paramPret);

                var paramLoc = comm.CreateParameter();
                paramLoc.ParameterName = "@locuri";
                paramLoc.Value = entity.Locuri;
                comm.Parameters.Add(paramLoc);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No excursie added !");
            }
        }

        public void update(int id, Excursie entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Excursii set obiectiv=@obiectiv, firma=@firma, oraPlecare=@ora, pret=@pret, locuri=@locuri where id=@id";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramObv = comm.CreateParameter();
                paramObv.ParameterName = "@obiectiv";
                paramObv.Value = entity.Obiectiv;
                comm.Parameters.Add(paramObv);

                var paramFirma = comm.CreateParameter();
                paramFirma.ParameterName = "@firma";
                paramFirma.Value = entity.Firma;
                comm.Parameters.Add(paramFirma);

                var paramOra = comm.CreateParameter();
                paramOra.ParameterName = "@ora";
                paramOra.Value = entity.OraPlecare;
                comm.Parameters.Add(paramOra);

                var paramPret = comm.CreateParameter();
                paramPret.ParameterName = "@pret";
                paramPret.Value = entity.Pret;
                comm.Parameters.Add(paramPret);

                var paramLoc = comm.CreateParameter();
                paramLoc.ParameterName = "@locuri";
                paramLoc.Value = entity.Locuri;
                comm.Parameters.Add(paramLoc);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No excursie modified !");
            }
        }
    }
}
