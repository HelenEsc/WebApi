using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebApi.Models;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    public class BooksController : ApiController
    {
        private WebApiContext db = new WebApiContext();
        static HttpClient client = new HttpClient();

        //GET: api/Books
        public async Task<Book> GetBooks()
        {
            Book book = null;

            HttpResponseMessage response = await client.GetAsync("http://fakerestapi.azurewebsites.net/api/v1/Books");
            if (response.IsSuccessStatusCode)
            {
                //Cannot deserialize the current JSON array into type 'WebApi.Models.Book' 
                book = await response.Content.ReadAsAsync<Book>();
            }
            return book;
        }

        // GET: api/Books/5

        //public async Task<Book> GetBook(int id)
        //{
        //    Book book = null;

        //    HttpResponseMessage response = await client.GetAsync("http://fakerestapi.azurewebsites.net/api/v1/Books/" + id);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        //Cannot deserialize the current JSON array into type 'WebApi.Models.Book' 
        //        book = await response.Content.ReadAsAsync<Book>();
        //    }
        //    return book;
        //}
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = book.id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.id == id) > 0;
        }
    }
}