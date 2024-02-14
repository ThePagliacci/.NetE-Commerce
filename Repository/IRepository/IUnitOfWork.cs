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
        ICompanyRepository Company {get;}
        IShoppingCartRepository ShoppingCart {get;}
        IApplicationUserRepository ApplicationUser {get;}
        IOrderHeaderRepository OrderHeader {get;}
        IOrderDetailRepository OrderDetail {get;}

        void Save();
    }
}