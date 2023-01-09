
namespace Lab3;

public partial class Author
{
    public int AuthorId { get; set; }

    public string FullName { get; set; } = null!;

    public string CountryOfOrigin { get; set; } = null!;

    public Author() { }

    public Author (int id, string fullName, string countryOfOrigin)
    {
        AuthorId = id;  
        FullName = fullName;
        CountryOfOrigin = countryOfOrigin;
    }

    public virtual ICollection<AuthorBook> AuthorBooks { get; } = new List<AuthorBook>();
}
