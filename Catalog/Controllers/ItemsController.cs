using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
using System;
using System.Linq;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository; //NOTE Dependency Injection

        public ItemsController(IItemsRepository repository) //NOTE Dependency Injection
        {
            this.repository = repository;
        }

        [HttpGet] //GET /items
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());

            return items;
        }

        [HttpGet("{id}")] //GET /items/{id}
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost] //POST /items
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                ID = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { ID = item.ID }, item.AsDto());
        }
    }
}