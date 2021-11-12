using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
using System;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemItemsRepository repository; //NOTE not ideal method here

        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }

        [HttpGet] //GET /items
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

        [HttpGet("{id}")] //GET /items/{id}
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }
    }
}