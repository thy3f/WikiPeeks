using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WikiPeeksAngular.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WikiPeeksAngular.Controllers
{
    //// TODO comment
    //[Route("api/[controller]")]
    public class WikiEntryController : Controller
    {
        WikiEntryDataAccessLayer objWikiEntry = new WikiEntryDataAccessLayer();

        [HttpGet]
        [Route("api/WikiEntry/Index")]
        public IEnumerable<WikiEntry> Index()
        {
            return objWikiEntry.GetAllWikiEntries();
        }

        [HttpPost]
        [Route("api/WikiEntry/Create")]
        public int Create([FromBody] WikiEntry wikiEntry)
        {
            return objWikiEntry.AddWikiEntry(wikiEntry);
        }

        [HttpGet]
        [Route("api/WikiEntry/Details/{id}")]
        public WikiEntry Details(int id)
        {
            return objWikiEntry.GetWikiEntryData(id);
        }

        [HttpPut]
        [Route("api/WikiEntry/Edit")]
        public int Edit([FromBody]WikiEntry wikiEntry)
        {
            return objWikiEntry.UpdateWikiEntry(wikiEntry);
        }

        [HttpDelete]
        [Route("api/WikiEntry/Delete/{id}")]
        public int Delete(int id)
        {
            return objWikiEntry.DeleteWikiEntry(id);
        }
    }
}
