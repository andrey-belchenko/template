using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImportantStuff.Data;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImportantStuff.Api.Controllers
{
    public class ProjectsController : ODataController
    {

     
        private readonly DataContext _dataContext;

        public ProjectsController( DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dataContext.Project);
        }

        
    }
}
