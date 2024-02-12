using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstRealProject.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category {get;}
        IProductRepository Product {get;}
        void Save();
    }
}