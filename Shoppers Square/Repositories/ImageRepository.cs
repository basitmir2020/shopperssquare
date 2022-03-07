using Shoppers_Square.Db;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Repositories
{
    public class ImageRepository : EntityBaseRepository<ImageModel>, IImagesRepository
    {
        public readonly AppDbContext _context;
        public ImageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
