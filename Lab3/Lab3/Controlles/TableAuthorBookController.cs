
namespace Lab3
{
    /// <summary>
    /// Логіка таблиці AuthorBook
    /// </summary>
    class AuthorBookController : SchoolController
    {
        public AuthorBook? authorBook { get; set; }

        public override async Task InsertDataAsync()
        {
            if (authorBook is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    await schoolContext.AddAsync(authorBook);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("AuthorBook object is not set!", nameof(authorBook));
        }

        public override async Task UpdateDataAsync()
        {
            if (authorBook is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    schoolContext.AuthorBooks.Update(authorBook);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("Author object is not set!", nameof(authorBook));
        }

        public override async Task DeleteDataAsync(int id)
        {
            using (schoolContext = new SchoolContext())
            {
                schoolContext.AuthorBooks.Remove(schoolContext.AuthorBooks.First(ab => ab.AuthorBookId == id));
                await schoolContext.SaveChangesAsync();
            }
        }


        public async Task<bool> CheckPKValueAsync(int id)
        {
            AuthorBook? authorBook = null;
            using (schoolContext = new SchoolContext())
            {
                authorBook = schoolContext.AuthorBooks.FirstOrDefault(a => a.AuthorBookId == id);
            }
            return authorBook == null ? false : true;
        }

        public override async Task SelectOneRowAsync(int id)
        {
            AuthorBook? aB;
            using (schoolContext = new SchoolContext())
            {
                aB = schoolContext.AuthorBooks.FirstOrDefault(ab => ab.AuthorBookId == id);
            }

            if (aB is not null)
                Console.WriteLine($"{aB.AuthorBookId} - {aB.BookFk} - {aB.AuthorFk}");
            else
                throw new ArgumentException("Invalid Id in parameters!", nameof(id));
        }
    }
}