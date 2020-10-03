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
        //private readonly BookService _bookService;
        public ProjectsController( DataContext dataContext)
        {
            _dataContext = dataContext;
            //_bookService = bookService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
          //  var book = new Book();
           // book.Id = "5bfd996f7b8e48dc15ff215e";
            //book.BookName = "Book3";
            //book.Pages.Add(new Page { Number = "1" });
            //book.Pages.Add(new Page { Number = "3" });
            //var b=_bookService.Create(book);
            return Ok(_dataContext.Project);
        }

        
    }
}
