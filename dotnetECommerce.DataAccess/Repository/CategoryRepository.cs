using dotnetECommerce.DataAccess.Data;
using dotnetECommerce.DataAccess.Repository.IRepository;
using dotnetECommerce.Models;

namespace dotnetECommerce.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Category obj)
    {
        _db.Update(obj);
    }
}