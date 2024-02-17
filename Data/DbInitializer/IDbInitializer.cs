using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FirstRealProject.Models;

namespace FirstRealProject.Data.DbInitializer
{
    public interface IDbInitializer
    {
        void Initialize();
    }
}