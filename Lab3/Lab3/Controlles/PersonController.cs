
namespace Lab3
{
    /// <summary>
    /// Логіка таблиці AuthorBook
    /// </summary>
    class PersonController : SchoolController
    {
        public Person? person { get; set; }

        public override async Task InsertDataAsync()
        {
            if (person is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    await schoolContext.AddAsync(person);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("AuthorBook object is not set!", nameof(person));
        }

        public override async Task UpdateDataAsync()
        {
            if (person is not null)
            {
                using (schoolContext = new SchoolContext())
                {
                    schoolContext.People.Update(person);
                    await schoolContext.SaveChangesAsync();
                }
            }
            else
                throw new ArgumentException("Author object is not set!", nameof(person));
        }

        public override async Task DeleteDataAsync(int id)
        {

            using (schoolContext = new SchoolContext())
            {
                var rList = schoolContext.Readers.ToList().Where(r => r.PersonId == id);
                schoolContext.Readers.RemoveRange(rList);
                await schoolContext.SaveChangesAsync();

                schoolContext.People.Remove(schoolContext.People.First(p => p.PersonId == id));
                await schoolContext.SaveChangesAsync();
            }
        }

        public async Task<bool> CheckPKValueAsync(int id)
        {
            Person? per = null;
            using (schoolContext = new SchoolContext())
            {
                per = schoolContext.People.FirstOrDefault(p => p.PersonId == id);
            }
            return per == null ? false : true;
        }

        public override async Task SelectOneRowAsync(int id)
        {
            Person? p;
            using (schoolContext = new SchoolContext())
            {
                p = schoolContext.People.FirstOrDefault(p => p.PersonId == id);
            }

            if (p is not null)
                Console.WriteLine($"{p.PersonId} - {p.FullName} - {p.IsHaveTicket}");
            else
                throw new ArgumentException("Invalid Id in parameters!", nameof(id));
        }
    }
}