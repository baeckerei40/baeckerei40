﻿using System.Web;
using System.Web.Mvc;

namespace baeckerei40_asp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
