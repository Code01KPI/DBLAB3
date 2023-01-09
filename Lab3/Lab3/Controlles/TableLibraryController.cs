
namespace Lab3
{
    /// <summary>
    /// Логіка таблиці AuthorBook
    /// </summary>
    class LibraryController : SchoolController
    {
        public Library? library { get; set; }

        public override async Task InsertDataAsync()
        {
            if (library is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    await schoolContext.AddAsync(library);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("AuthorBook object is not set!", nameof(library));
        }

        public override async Task UpdateDataAsync()
        {
            if (library is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    schoolContext.Libraries.Update(library);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("Author object is not set!", nameof(library));
        }

        public override async Task DeleteDataAsync(int id)
        {

            using (schoolContext = new SchoolContext())
            {
                var bList = schoolContext.Books.ToList().Where(b => b.BkLibraryId == id);
                schoolContext.Books.RemoveRange(bList);
                await schoolContext.SaveChangesAsync();

                var rList = schoolContext.Readers.ToList().Where(r => r.LibraryId == id);
                schoolContext.Readers.RemoveRange(rList);
                await schoolContext.SaveChangesAsync();

                schoolContext.Libraries.Remove(schoolContext.Libraries.First(l => l.Id == id));
                await schoolContext.SaveChangesAsync();
            }
        }

        public async Task<bool> CheckPKValueAsync(int id)
        {
            Library? lib = null;
            using (schoolContext = new SchoolContext())
            {
                lib = schoolContext.Libraries.FirstOrDefault(l => l.Id == id);
            }
            return lib == null ? false : true;
        }

        public override async Task SelectOneRowAsync(int id)
        {
            Library? l;
            using (schoolContext = new SchoolContext())
            {
                l = schoolContext.Libraries.FirstOrDefault(l => l.Id == id);
            }

            if (l is not null)
                Console.WriteLine($"{l.Id} - {l.GivingTime} - {l.ReturnTime} - {l.ActualReturnTime}");
            else
                throw new ArgumentException("Invalid Id in parameters!", nameof(id));
        }
    }
}