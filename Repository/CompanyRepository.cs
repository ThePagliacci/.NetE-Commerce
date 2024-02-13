using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FirstRealProject.Data;
using FirstRealProject.Models;
using FirstRealProject.Repository.IRepository;
using FirstRealProject.Repository.Repository;

namespace FirstRealProject.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDBContext _db;
        public CompanyRepository(ApplicationDBContext db):base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}