using Microsoft.EntityFrameworkCore;

namespace GreenThump.Database
{
	public class GreenThumbRepository<T> where T : class
	{
		private readonly GreenThumbDb _context;
		private readonly DbSet<T> _dbSet;

		public GreenThumbRepository(GreenThumbDb context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}


		public List<T> GetAll()
		{
			return _dbSet.ToList();
			//return _context.Plants.Include(p => p.Instructions).ToList();
		}

		public T? GetByID(int id)
		{
			return _dbSet.Find(id);
			//return _context.Plants.Include(p => p.Instructions).FirstOrDefault(p => p.Id == id);
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
			//_context.Plants.Add(plant);
		}

		public void Remove(int Id)
		{
			T? entityToRemove = GetByID(Id);
			if (entityToRemove != null)
			{
				_dbSet.Remove(entityToRemove);
			}

			//    Plant? PlantToRemove = _context.Plants.FirstOrDefault(p =>p.Id == plant.Id);
			//    if (PlantToRemove != null)
			//    {
			//        _context.Plants.Remove(PlantToRemove);
			//    }
		}

		public void Complete()
		{
			_context.SaveChanges();
		}
	}
}
