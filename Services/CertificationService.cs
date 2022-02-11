using System.Collections.Generic;
using System.Linq;
using Certificados.Models;

namespace Certificados.Services
{
    public class CertificationService : ICertificationService<Certification>
    {
        private List<Certification> _certifications = new();

        public int Add(Certification entity)
        {
            entity.Id = _certifications.Count;
            _certifications.Add(entity);

            return entity.Id;
        }

        public bool Update(int id, Certification entity)
        {
            try
            {
                _certifications[id] = entity;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                if (!_certifications[id].bDeleted)
                {
                    _certifications[id].Delete();
                    return true;
                }
                else
                {
                    // Finge q já tá deletado kk
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Certification> GetAll()
        {
            // Retorna somente os certificados que não
            // "estão deletados".
            var nonDeleted = new List<Certification>();
            foreach (var item in _certifications)
                if (!item.bDeleted)
                    nonDeleted.Add(item);

            return nonDeleted;
        }

        public Certification GetById(int id)
        {
            try
            {
                return _certifications[id];
            }
            catch
            {
                return null;
            }
        }

        public int NextId()
        {
            return _certifications.Count;
        }
    }
}