using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistence
{
    public class RepositoryException : ApplicationException
    {
        public RepositoryException() { }
        public RepositoryException(String mess) : base(mess) { }
        public RepositoryException(String mess, Exception e) : base(mess, e) { }
    }

    public interface IRepository<ID, E>
    {
        E findOne(ID id);
        IEnumerable<E> findAll();
        void save(E entity);
        void delete(ID id);
        void update(ID id, E entity);
    }
}
