using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENJobExchange.DAL
{
    public partial class Repository
    {
        //Get Employment Network ID
        public long getENID() 
        {  
            var ENID =(
                from d in db.Account_EN
                select d.ENID).Single();
            return ENID;
        }
    }
}