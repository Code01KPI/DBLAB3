
namespace Lab3
{
    /// <summary>
    /// Логіка таблиці AuthorBook
    /// </summary>
    class ReaderController : SchoolController
    {
        public Reader? reader { get; set; }

        public override async Task InsertDataAsync()
        {
            if (reader is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    await schoolContext.AddAsync(reader);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("Reader object is not set!", nameof(reader));
        }

        public override async Task UpdateDataAsync()
        {
            if (reader is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    schoolContext.Readers.Update(reader);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("Author object is not set!", nameof(reader));
        }

        public override async Task DeleteDataAsync(int id)
        {
            using (schoolContext = new SchoolContext())
            {
                schoolContext.Readers.Remove(schoolContext.Readers.First(r => r.Id == id));
                await schoolContext.SaveChangesAsync();
            }
        }


        public async Task<bool> CheckPKValueAsync(int id)
        {
            Reader? reader = null;
            using (schoolContext = new SchoolContext())
            {
                reader = schoolContext.Readers.FirstOrDefault(r => r.Id == id);
            }
            return reader == null ? false : true;
        }

        public override async Task SelectOneRowAsync(int id)
        {
            Reader? r;
            using (schoolContext = new SchoolContext())
            {
                r = schoolContext.Readers.FirstOrDefault(r => r.Id == id);
            }

            if (r is not null)
                Console.WriteLine($"{r.Id} - {r.LibraryId} - {r.PersonId} - {r.TakenBook}");
            else
                throw new ArgumentException("Invalid Id in parameters!", nameof(id));
        }
    }
}