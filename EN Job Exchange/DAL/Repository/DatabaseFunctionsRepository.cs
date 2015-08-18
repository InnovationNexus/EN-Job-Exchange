using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENJobExchange.DAL
{
    public class DatabaseFunctionsRepository
    {
        [System.Data.Entity.DbFunction("enjeDataModel.Store", "fncCalcZipCodeDistance")]
        public static decimal? fncCalcZipCodeDistance(string zipCode1, string zipCode2)
        {
            throw new NotSupportedException("Direct calls are not supported.");
        }
    }
}
