using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var item in logics)
            {
                if (!item.Success)
                {
                    //hatalı olan kural return edilir
                    return item;
                }
            }

            return null;
        }
    }
}
