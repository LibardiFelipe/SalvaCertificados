using System.Collections.Generic;

namespace Certificados.Services
{
    public interface ICertificationService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        bool Delete(int id);
        bool Update(int id, T newEntity);
        int NextId();
    }
}