
namespace Lab3
{
    /// <summary>
    /// Логіка таблиці Author
    /// </summary>
    class AuthorController : SchoolController
    {
        public Author? author { get; set; }

        public override async Task InsertDataAsync()
        {
            if (author is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    await schoolContext.AddAsync(author);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("Author object is not set!", nameof(author));
        }

        public override async Task UpdateDataAsync()
        {
            if (author is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    schoolContext.Authors.Update(author);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("Author object is not set!", nameof(author));
        }

        public override async Task DeleteDataAsync(int id)
        {

            using (schoolContext = new SchoolContext())
            {
                var aBList = schoolContext.AuthorBooks.ToList().Where(ab => ab.AuthorFk == id);
                schoolContext.AuthorBooks.RemoveRange(aBList);
                await schoolContext.SaveChangesAsync();

                schoolContext.Authors.Remove(schoolContext.Authors.First(a => a.AuthorId == id));
                await schoolContext.SaveChangesAsync();
            }
        }

        public override async Task SelectOneRowAsync(int id)
        {
            Author? a;
            using (schoolContext = new SchoolContext())
            {
                a = schoolContext.Authors.FirstOrDefault(a => a.AuthorId == id);
            }

            if (a is not null)
                Console.WriteLine($"{a.AuthorId} - {a.FullName} - {a.CountryOfOrigin}");
            else
                throw new ArgumentException("Invalid Id in parameters!", nameof(id));
        }

        public async Task<bool> CheckPKValueAsync(int PK)
        {
            Author? author = null;
            using (schoolContext = new SchoolContext())
            {
                author = schoolContext.Authors.First<Author>(a => a.AuthorId == PK);
            }
            return author == null ? false : true;
        }
    }
}
