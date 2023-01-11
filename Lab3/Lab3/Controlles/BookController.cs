
namespace Lab3
{
    /// <summary>
    /// Логіка таблиці AuthorBook
    /// </summary>
    class BookController : SchoolController
    {
        public Book? book { get; set; }

        public override async Task InsertDataAsync()
        {
            if (book is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    await schoolContext.AddAsync(book);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("AuthorBook object is not set!", nameof(book));
        }

        public override async Task UpdateDataAsync()
        {
            if (book is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    schoolContext.Books.Update(book);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("Author object is not set!", nameof(book));
        }

                public override async Task DeleteDataAsync(int id)
        {

            using (schoolContext = new SchoolContext())
            {
                var aBList = schoolContext.AuthorBooks.ToList().Where(ab => ab.BookFk == id);
                schoolContext.AuthorBooks.RemoveRange(aBList);
                await schoolContext.SaveChangesAsync();

                schoolContext.Books.Remove(schoolContext.Books.First(a => a.BookId == id));
                await schoolContext.SaveChangesAsync();
            }
        }


        public async Task<bool> CheckPKValueAsync(int id)
        {
            Book? book = null;
            using (schoolContext = new SchoolContext())
            {
                book = schoolContext.Books.FirstOrDefault(a => a.BookId == id);
            }
            return book == null ? false : true;
        }

        public override async Task SelectOneRowAsync(int id)
        {
            Book? b;
            using (schoolContext = new SchoolContext())
            {
                b = schoolContext.Books.FirstOrDefault(b => b.BookId == id);
            }

            if (b is not null)
                Console.WriteLine($"{b.BookId} - {b.DateOfPublication} - {b.NumberOfPages} - " +
                    $"{b.Genre} - {b.BkLibraryId} - {b.BookName}");
            else
                throw new ArgumentException("Invalid Id in parameters!", nameof(id));
        }
    }
}