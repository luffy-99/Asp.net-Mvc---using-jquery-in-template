using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.Infrastructủe
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopOnlineDbContext dbContext;
        public ShopOnlineDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopOnlineDbContext());
        }
        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
