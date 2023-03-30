using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfAboutDal :GenericRepository<About>,IAboutDal
    {
        public EfAboutDal(Context context) : base (context)
        {

        }
    }
}
