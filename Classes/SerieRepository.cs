using Series.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Classes
{
    class SerieRepository : IRepository<Serie>
    {

        private List<Serie> seriesList = new List<Serie>();
        public void Delete(int id)
        {
            seriesList[id].Delete();
        }

        public void Insert(Serie entity)
        {
            seriesList.Add(entity);
        }

        public void Update(int id, Serie entity)
        {
            seriesList[id] = entity;
        }

        public List<Serie> List()
        {
            return seriesList;
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Serie ReturnById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
