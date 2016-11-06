using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    /// <summary>
    /// Instance to hold the results.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultModel <T> where T:class
    {
        public bool Status { get; set; }
        public T Entity { get; set; }
    }
}