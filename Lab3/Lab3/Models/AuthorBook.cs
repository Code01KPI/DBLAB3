
namespace Lab3;

public partial class AuthorBook
{
    public int AuthorBookId { get; set; }

    public int BookFk { get; set; }

    public int AuthorFk { get; set; }

    public AuthorBook() { }

    public AuthorBook(int id, int bFK, int aFK)
    {
        AuthorBookId = id;
        BookFk = bFK;
        AuthorFk = aFK;
    }

    public virtual Author AuthorFkNavigation { get; set; } = null!;

    public virtual Book BookFkNavigation { get; set; } = null!;
}
