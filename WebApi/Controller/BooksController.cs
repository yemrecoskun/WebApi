using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.DataSource;
using WebApi.Model;

namespace WebApi
{
    [Route("api/books")]
    public class BooksController : Controller
    {
        //postman api/books
        [HttpGet()]
        public IActionResult GetCategories()
        {
            return Ok(ApiDataSource.Current.categories);
        }

        //postman api/books/2
        [HttpGet("{Id}")]
        public IActionResult GetCategories(int Id)
        {
            try
            {
                var data = ApiDataSource.Current.categories.FirstOrDefault(c => c.Id == Id);
                if (data == null) throw new Exception("Veri Bulunamadı");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        //postman api/books/author/getvalue
        [HttpGet("author/{Name}")]
        public IActionResult GetAuthors(string name)
        {
            var data = ApiDataSource.Current.categories.SelectMany(b => b.bookOfInterests.Select(i => new { i.Id, i.Name, i.Author }).Where(a => a.Author == name)).FirstOrDefault();
            if (data == null) return NotFound();
            return Ok(data);
        }
        //örnek api/books/categories/Macera
        [HttpGet("categories/{Name}")]
        public IActionResult GetCategories1(string Name)
        {
            var data = ApiDataSource.Current.categories.FirstOrDefault(c => c.Name == Name);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult GetCategoriesPost([FromBody] Categories apiData)
        {
            ApiDataSource.Current.categories.Add(apiData);
            return Ok(apiData);
        }
        [HttpPut]
        public IActionResult GetCategoriesPut([FromBody] Categories apiData)
        {
            var editedCategories = ApiDataSource.Current.categories.FirstOrDefault(x => x.Id == apiData.Id);
            editedCategories.bookOfInterests = apiData.bookOfInterests;
            editedCategories.Name = apiData.Name;
            return Ok(apiData);
        }
        [HttpDelete("{id}")]
        public void GetCategoriesDelete(int id)
        {
            var deletedCategories = ApiDataSource.Current.categories.FirstOrDefault(x => x.Id == id);
            ApiDataSource.Current.categories.Remove(deletedCategories);
        }
    }
}