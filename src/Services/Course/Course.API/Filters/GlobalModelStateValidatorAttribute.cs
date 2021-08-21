using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Course.API.Extensions;
using ELearning.Common.Exceptions;

namespace Course.API.Filters
{
    public class GlobalModelStateValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new CustomValidationException(context.ModelState.GetErrors());
            }

            base.OnActionExecuting(context);
        }
    }
}
