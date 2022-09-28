using apiSwagger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiSwagger.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly BookContext _context;

        public BookRepository(BookContext bookContext)
        {
            _context = bookContext;
        }

        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int Id)
        {
            var bookDelete = await _context.Books.FindAsync(Id);
            _context.Books.Remove(bookDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int Id)
        {
            return await _context.Books.FindAsync(Id);
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }
    }
}
