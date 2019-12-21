using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using myProject.Data;
using myProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Filters
{
    public class ShareCategoriesFilter : IActionFilter
    {
        private readonly BlogPlatformContext _context;
        private readonly ILogger _logger;

        public ShareCategoriesFilter(BlogPlatformContext context, ILogger<ShareCategoriesFilter> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller is Controller controller)
            {
                controller.ViewBag.filterCategories = _context.Categories.ToList();
            }
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // do something after the action executes
        }
    }
}
