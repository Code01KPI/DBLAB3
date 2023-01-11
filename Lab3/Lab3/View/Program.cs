using System.Text.RegularExpressions;
using Lab3;

AuthorController authorController = new AuthorController();
AuthorBookController authorBookController = new AuthorBookController();
BookController bookController = new BookController();   
LibraryController libraryController = new LibraryController();
PersonController personController = new PersonController();
ReaderController readerController = new ReaderController();

string? strItem;
int item;
int item1, item11;

try
{
    while (true)
    {
        Console.WriteLine("1. Work with data");
        Console.WriteLine("4. Exit");
        Console.Write("Choose menu item: ");

        strItem = Console.ReadLine();
        if (!int.TryParse(strItem, out item) || string.IsNullOrWhiteSpace(strItem))
        {
            Console.WriteLine("It's invalid menu item!\n");
            continue;
        }

        int id;
        string full_name, country_of_origin, strId;

        int book_fk, author_fk;
        string strBook_fk, strAuthor_fk;

        int date_of_publication, number_of_pages, bk_library_id;
        string strDate_of_publication, strNumber_of_pages, genre, strBk_library_id, book_name;

        DateOnly giving_time, return_time, actual_return_time;
        string strGiving_time, strReturn_time, strActual_return_time;
        string[] strDate = new string[3];
        int[] date = new int[3];

        int library_id, person_id;
        string strLibrary_id, strPerson_id, taken_book;

        string personFull_name, strIs_have_ticket;
        bool is_have_ticket;

        bool isParse = true;

        switch (item) 
        {
            case 1:
                while (true)
                {
                    Console.WriteLine("\n1. Insert data");
                    Console.WriteLine("2. Update data");
                    Console.WriteLine("3. Delete data");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose menu item: ");

                    if (!int.TryParse(Console.ReadLine(), out item1))
                        throw new Exception("Invalid menu item!");
                    switch (item1)
                    {
                        #region Insert data
                        case 1:
                            while (true)
                            {
                                item11 = ChooseTable();
                                switch (item11)
                                {
                                    case 1:
                                        while (true)
                                        {
                                            Console.Write("Insert *author_id*(Attention! PK should't be repeated): ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of *author_id*!");
                                                continue;
                                            }
                                            else if (await authorController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("It's incorrect value of *author_id*(Dublicated)!");
                                                continue;
                                            }

                                            Console.Write("Insert *full_name*: ");
                                            full_name = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(full_name))
                                            {
                                                Console.WriteLine("It's incorrect value of *full_name*");
                                                continue;
                                            }

                                            Console.Write("Insert *country_of_origin*: ");
                                            country_of_origin = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(country_of_origin))
                                            {
                                                Console.WriteLine("It's incorrect value of *country_of_origin*");
                                                continue;
                                            }

                                            authorController.author = new Author(id, full_name, country_of_origin);
                                            await authorController.InsertDataAsync();

                                            Console.Write("Finish entering data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.Write("Insert *author_book_id*(Attention! PK should't be repeated): ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of *author_book_id*!");
                                                continue;
                                            }
                                            else if (await authorBookController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("It's incorrect value of *author_book_id*(Dublicated)!");
                                                continue;
                                            }

                                            Console.Write("Insert *book_fk*(Attention! The id column from the Book table must have the same value!): ");
                                            strBook_fk = Console.ReadLine();
                                            if (!int.TryParse(strBook_fk, out book_fk))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_fk*!");
                                                continue;
                                            }
                                            else if (!await bookController.CheckPKValueAsync(book_fk))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_fk*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            Console.Write("Insert *author_fk*(Attention! The id column from the Author table must have the same value!): ");
                                            strAuthor_fk = Console.ReadLine();
                                            if (!int.TryParse(strAuthor_fk, out author_fk))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_fk*!");
                                                continue;
                                            }
                                            else if (!await authorController.CheckPKValueAsync(author_fk))
                                            {
                                                Console.WriteLine("It's incorrect value of *author_fk*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            authorBookController.authorBook = new AuthorBook(id, book_fk, author_fk);
                                            await authorBookController.InsertDataAsync();

                                            Console.Write("Finished entering data? ");
                                            if (Console.ReadLine() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            Console.Write("Insert *book_id*(Attention! PK should't be repeated): ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_id*!");
                                                continue;
                                            }
                                            else if (await bookController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_id*(Dublicated)!");
                                                continue;
                                            }

                                            Console.Write("Insert *date_of_publication*: ");
                                            strDate_of_publication = Console.ReadLine();
                                            if (!int.TryParse(strDate_of_publication, out date_of_publication))
                                            {
                                                Console.WriteLine("It's incorrect value of *date_of_publication*!");
                                                continue;
                                            }

                                            Console.Write("Insert *number_of_pages*: ");
                                            strNumber_of_pages = Console.ReadLine();
                                            if (!int.TryParse(strNumber_of_pages, out number_of_pages))
                                            {
                                                Console.WriteLine("It's incorrect value of *number_of_pages*!");
                                                continue;
                                            }

                                            Console.Write("Insert *genre*:");
                                            genre = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(genre))
                                            {
                                                Console.WriteLine("It's incorrect value of *genre*!");
                                                continue;
                                            }

                                            Console.Write("Insert *bk_library_id*(Attention! The id column from the Author table must have the same value!):");
                                            strBk_library_id = Console.ReadLine();
                                            if (!int.TryParse(strBk_library_id, out bk_library_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *bk_library_id*!");
                                                continue;
                                            }
                                            else if (!await libraryController.CheckPKValueAsync(bk_library_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *bk_library_id*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            Console.Write("Insert *book_name*:");
                                            book_name = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(book_name))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_name*!");
                                                continue;
                                            }

                                            bookController.book = new Book(id, date_of_publication, number_of_pages, genre, bk_library_id, book_name);
                                            await bookController.InsertDataAsync();

                                            Console.Write("Finished entering data? ");
                                            if (Console.ReadLine() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            Console.Write("Insert *id*(Attention! PK should't be repeated): ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_id*!");
                                                continue;
                                            }
                                            else if (await libraryController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("It's incorrect value of *id*(Dublicated)!");
                                                continue;
                                            }

                                            Console.Write("Insert *giving_time*(yyyy.mm.dd): ");
                                            strGiving_time = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(strGiving_time) || !CheckDateString(strGiving_time))
                                            {
                                                Console.WriteLine("It's incorrect value of *giving_time*!");
                                                continue;
                                            }
                                            strDate = strGiving_time.Split(".");

                                            for (int i = 0; i < 3; i++)
                                            {
                                                if (!int.TryParse(strDate[i], out date[i]))
                                                {
                                                    Console.WriteLine("It's incorrect value of *giving_time*!");
                                                    isParse = false;
                                                    break;
                                                }
                                            }

                                            if (isParse == false)
                                            {
                                                isParse = true;
                                                continue;
                                            }


                                            giving_time = new DateOnly(date[0], date[1], date[2]);

                                            Console.Write("Insert *return_time*(yyyy.mm.dd): ");
                                            strReturn_time = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(strReturn_time) || !CheckDateString(strReturn_time))
                                            {
                                                Console.WriteLine("It's incorrect value of *return_time*!");
                                                continue;
                                            }
                                            strDate = strReturn_time.Split(".");

                                            for (int i = 0; i < 3; i++)
                                            {
                                                if (!int.TryParse(strDate[i], out date[i]))
                                                {
                                                    Console.WriteLine("It's incorrect value of *return_time*!");
                                                    isParse = false;
                                                    break;
                                                }
                                            }

                                            if (isParse == false)
                                            {
                                                isParse = true;
                                                continue;
                                            }

                                            return_time = new DateOnly(date[0], date[1], date[2]);

                                            Console.Write("Insert *actual_return_time*(yyyy.mm.dd): ");
                                            strActual_return_time = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(strActual_return_time) || !CheckDateString(strActual_return_time))
                                            {
                                                Console.WriteLine("It's incorrect value of *actual_return_time*!");
                                                continue;
                                            }
                                            strDate = strActual_return_time.Split(".");

                                            for (int i = 0; i < 3; i++)
                                            {
                                                if (!int.TryParse(strDate[i], out date[i]))
                                                {
                                                    Console.WriteLine("It's incorrect value of *actual_return_time*!");
                                                    isParse = false;
                                                    break;
                                                }
                                            }

                                            if (isParse == false)
                                            {
                                                isParse = true;
                                                continue;
                                            }

                                            actual_return_time = new DateOnly(date[0], date[1], date[2]);

                                            libraryController.library = new Library(id, giving_time, return_time, actual_return_time);
                                            await libraryController.InsertDataAsync();

                                            Console.Write("Finished entering data? ");
                                            if (Console.ReadLine() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 5:
                                        while (true)
                                        {
                                            Console.Write("Insert *person_id*(Attention! PK should't be repeated): ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of *person_id*!");
                                                continue;
                                            }
                                            else if (await personController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("It's incorrect value of *person_id*(Dublicated)!");
                                                continue;
                                            }

                                            Console.Write("Insert *full_name*: ");
                                            personFull_name = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(personFull_name))
                                            {
                                                Console.WriteLine("It's incorrect value of *full_name*!");
                                                continue;
                                            }

                                            Console.Write("Insert *is_have_ticket*: ");
                                            strIs_have_ticket = Console.ReadLine();
                                            if (!bool.TryParse(strIs_have_ticket, out is_have_ticket))
                                            {
                                                Console.WriteLine("It's incorrect value of *is_have_ticket*!");
                                                continue;
                                            }

                                            personController.person = new Person(id, personFull_name, is_have_ticket);

                                            await personController.InsertDataAsync();

                                            Console.Write("Finished entering data? ");
                                            if (Console.ReadLine() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 6:
                                        while (true)
                                        {
                                            Console.Write("Insert *id*(Attention! PK should't be repeated): ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of *id*!");
                                                continue;
                                            }
                                            else if (await readerController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("It's incorrect value of *id*(Dublicated)!");
                                                continue;
                                            }

                                            Console.Write("Insert *library_id*(Attention! The id column from the Library table must have the same value!): ");
                                            strLibrary_id = Console.ReadLine();
                                            if (!int.TryParse(strLibrary_id, out library_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *library_id*!");
                                                continue;
                                            }
                                            else if (!await libraryController.CheckPKValueAsync(library_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *library_id*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            Console.Write("Insert *person_id*(Attention! The id column from the Person table must have the same value!): ");
                                            strPerson_id = Console.ReadLine();
                                            if (!int.TryParse(strPerson_id, out person_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *person_id*!");
                                                continue;
                                            }
                                            else if (!await personController.CheckPKValueAsync(person_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *person_id*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            Console.Write("Insert *taken_book*: ");
                                            taken_book = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(taken_book))
                                            {
                                                Console.WriteLine("It's incorrect value of *taken_book*!");
                                                continue;
                                            }

                                            readerController.reader = new Reader(id, library_id, person_id, taken_book);
                                            await readerController.InsertDataAsync();

                                            Console.Write("Finished entering data? ");
                                            if (Console.ReadLine() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 7:
                                        return;
                                    default:
                                        Console.WriteLine("There are no such menu item!");
                                        break;
                                }
                            }
                        #endregion
                        #region Update data
                        case 2:
                            while (true)
                            {
                                item11 = ChooseTable();
                                switch (item11)
                                {
                                    case 1:
                                        while (true)
                                        {
                                            Console.Write("Insert id of row for update: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id!");
                                                continue;
                                            }
                                            else if (!await authorController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            Console.Write("Insert new *full_name*: ");
                                            full_name = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(full_name))
                                            {
                                                Console.WriteLine("It's incorrect value of *full_name*!");
                                                continue;
                                            }

                                            Console.Write("Insert new *country_of_origin*: ");
                                            country_of_origin = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(country_of_origin))
                                            {
                                                Console.WriteLine("It's incorrect value of *country_of_origin*!");
                                                continue;
                                            }

                                            authorController.author = new Author(id, full_name, country_of_origin);

                                            await authorController.SelectOneRowAsync(id);
                                            await authorController.UpdateDataAsync();
                                            await authorController.SelectOneRowAsync(id);

                                            Console.Write("Finish updating data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.Write("Insert id of row for update: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id!");
                                                continue;
                                            }
                                            if (!await authorBookController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            Console.Write("Insert new *book_fk*: ");
                                            strBook_fk = Console.ReadLine();
                                            if (!int.TryParse(strBook_fk, out book_fk))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_fk*!");
                                                continue;
                                            }
                                            else if (!await bookController.CheckPKValueAsync(book_fk))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_fk*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            Console.Write("Insert new *author_fk*: ");
                                            strAuthor_fk = Console.ReadLine();
                                            if (!int.TryParse(strAuthor_fk, out author_fk))
                                            {
                                                Console.WriteLine("It's incorrect value of *author_fk*!");
                                                continue;
                                            }
                                            else if (!await authorController.CheckPKValueAsync(author_fk))
                                            {
                                                Console.WriteLine("It's incorrect value of *author_fk*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            authorBookController.authorBook = new AuthorBook(id, book_fk, author_fk);

                                            await authorBookController.SelectOneRowAsync(id);
                                            await authorBookController.UpdateDataAsync();
                                            await authorBookController.SelectOneRowAsync(id);

                                            Console.Write("Finish updating data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            Console.Write("Insert id of row for update: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id!");
                                                continue;
                                            }
                                            if (!await bookController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            Console.Write("Insert new *date_of_publication*: ");
                                            strDate_of_publication = Console.ReadLine();
                                            if (!int.TryParse(strDate_of_publication, out date_of_publication))
                                            {
                                                Console.WriteLine("It's incorrect value of *date_of_publication*!");
                                                continue;
                                            }

                                            Console.Write("Insert new *number_of_pages*: ");
                                            strNumber_of_pages = Console.ReadLine();
                                            if (!int.TryParse(strNumber_of_pages, out number_of_pages))
                                            {
                                                Console.WriteLine("It's incorrect value of *number_of_pages*!");
                                                continue;
                                            }

                                            Console.Write("Insert new *genre*:");
                                            genre = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(genre))
                                            {
                                                Console.WriteLine("It's incorrect value of *genre*!");
                                                continue;
                                            }

                                            Console.Write("Insert new *bk_library_id*:");
                                            strBk_library_id = Console.ReadLine();
                                            if (!int.TryParse(strBk_library_id, out bk_library_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *bk_library_id*!");
                                                continue;
                                            }
                                            else if (!await libraryController.CheckPKValueAsync(bk_library_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *bk_library_id*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            Console.Write("Insert new *book_name*:");
                                            book_name = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(book_name))
                                            {
                                                Console.WriteLine("It's incorrect value of *book_name*!");
                                                continue;
                                            }

                                            bookController.book = new Book(id, date_of_publication, number_of_pages, genre, bk_library_id, book_name);

                                            await bookController.SelectOneRowAsync(id);
                                            await bookController.UpdateDataAsync();
                                            await bookController.SelectOneRowAsync(id);

                                            Console.Write("Finish updating data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            Console.Write("Insert id of row for update: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id!");
                                                continue;
                                            }
                                            if (!await libraryController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            Console.Write("Insert new *giving_time*(yyyy.mm.dd): ");
                                            strGiving_time = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(strGiving_time) || !CheckDateString(strGiving_time))
                                            {
                                                Console.WriteLine("It's incorrect value of *giving_time*!");
                                                continue;
                                            }
                                            strDate = strGiving_time.Split(".");

                                            for (int i = 0; i < 3; i++)
                                            {
                                                if (!int.TryParse(strDate[i], out date[i]))
                                                {
                                                    Console.WriteLine("It's incorrect value of *giving_time*!");
                                                    isParse = false;
                                                    break;
                                                }
                                            }

                                            if (isParse == false)
                                            {
                                                isParse = true;
                                                continue;
                                            }

                                            giving_time = new DateOnly(date[0], date[1], date[2]);

                                            Console.Write("Insert new *return_time*(yyyy.mm.dd): ");
                                            strReturn_time = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(strReturn_time) || !CheckDateString(strReturn_time))
                                            {
                                                Console.WriteLine("It's incorrect value of *return_time*!");
                                                continue;
                                            }
                                            strDate = strReturn_time.Split(".");

                                            for (int i = 0; i < 3; i++)
                                            {
                                                if (!int.TryParse(strDate[i], out date[i]))
                                                {
                                                    Console.WriteLine("It's incorrect value of *return_time*!");
                                                    isParse = false;
                                                    break;
                                                }
                                            }

                                            if (isParse == false)
                                            {
                                                isParse = true;
                                                continue;
                                            }

                                            return_time = new DateOnly(date[0], date[1], date[2]);

                                            Console.Write("Insert new *actual_return_time*(yyyy.mm.dd): ");
                                            strActual_return_time = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(strActual_return_time) || !CheckDateString(strActual_return_time))
                                            {
                                                Console.WriteLine("It's incorrect value of *actual_return_time*!");
                                                continue;
                                            }
                                            strDate = strActual_return_time.Split(".");

                                            for (int i = 0; i < 3; i++)
                                            {
                                                if (!int.TryParse(strDate[i], out date[i]))
                                                {
                                                    Console.WriteLine("It's incorrect value of *actual_return_time*!");
                                                    isParse = false;
                                                    break;
                                                }
                                            }

                                            if (isParse == false)
                                            {
                                                isParse = true;
                                                continue;
                                            }

                                            actual_return_time = new DateOnly(date[0], date[1], date[2]);

                                            libraryController.library = new Library(id, giving_time, return_time, actual_return_time);

                                            await libraryController.SelectOneRowAsync(id);
                                            await libraryController.UpdateDataAsync();
                                            await libraryController.SelectOneRowAsync(id);

                                            Console.Write("Finish updating data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 5:
                                        while (true)
                                        {
                                            Console.Write("Insert id of row for update: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id!");
                                                continue;
                                            }
                                            if (!await personController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            Console.Write("Insert new *full_name*: ");
                                            personFull_name = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(personFull_name))
                                            {
                                                Console.WriteLine("It's incorrect value of *full_name*!");
                                                continue;
                                            }

                                            Console.Write("Insert new *is_have_ticket*: ");
                                            strIs_have_ticket = Console.ReadLine();
                                            if (!bool.TryParse(strIs_have_ticket, out is_have_ticket))
                                            {
                                                Console.WriteLine("It's incorrect value of *is_have_ticket*!");
                                                continue;
                                            }

                                            personController.person = new Person(id, personFull_name, is_have_ticket);

                                            await personController.SelectOneRowAsync(id);
                                            await personController.UpdateDataAsync();
                                            await personController.SelectOneRowAsync(id);

                                            Console.Write("Finish updating data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 6:
                                        while (true)
                                        {
                                            Console.Write("Insert id of row for update: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id!");
                                                continue;
                                            }
                                            if (!await readerController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            Console.Write("Insert new *library*: ");
                                            strLibrary_id = Console.ReadLine();
                                            if (!int.TryParse(strLibrary_id, out library_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *library_id*!");
                                                continue;
                                            }
                                            else if (!await libraryController.CheckPKValueAsync(library_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *library_id*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            Console.Write("Insert new *person_id*: ");
                                            strPerson_id = Console.ReadLine();
                                            if (!int.TryParse(strPerson_id, out person_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *person_id*!");
                                                continue;
                                            }
                                            else if (!await personController.CheckPKValueAsync(person_id))
                                            {
                                                Console.WriteLine("It's incorrect value of *person_id*!(There is no required data in the parent table!)");
                                                continue;
                                            }

                                            Console.Write("Insert new *taken_book*:");
                                            taken_book = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(taken_book))
                                            {
                                                Console.WriteLine("It's incorrect value of *taken_book*!");
                                                continue;
                                            }

                                            readerController.reader = new Reader(id, library_id, person_id, taken_book);

                                            await readerController.SelectOneRowAsync(id);
                                            await readerController.UpdateDataAsync();
                                            await readerController.SelectOneRowAsync(id);

                                            Console.Write("Finish updating data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 7:
                                        return;
                                    default:
                                        Console.WriteLine("There are no such menu item!");
                                        break;
                                }
                            }
                            break;
                        #endregion
                        #region Delete data
                        case 3:
                            while (true)
                            {
                                item11 = ChooseTable();
                                switch (item11)
                                {
                                    case 1: 
                                        while (true)
                                        {
                                            Console.Write("Insert row id for deleting: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id");
                                                continue;
                                            }
                                            else if (!await authorController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            await authorController.DeleteDataAsync(id);

                                            Console.Write("Finish deleting data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.Write("Insert row id for deleting: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id");
                                                continue;
                                            }
                                            else if (!await authorBookController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            await authorBookController.DeleteDataAsync(id);

                                            Console.Write("Finish deleting data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 3:
                                        while (true)
                                        {
                                            Console.Write("Insert row id for deleting: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id");
                                                continue;
                                            }
                                            else if (!await bookController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            await bookController.DeleteDataAsync(id);

                                            Console.Write("Finish deleting data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 4:
                                        while (true)
                                        {
                                            Console.Write("Insert row id for deleting: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id");
                                                continue;
                                            }
                                            else if (!await libraryController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            await libraryController.DeleteDataAsync(id);

                                            Console.Write("Finish deleting data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 5:
                                        while (true)
                                        {
                                            Console.Write("Insert row id for deleting: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id");
                                                continue;
                                            }
                                            else if (!await personController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            await personController.DeleteDataAsync(id);

                                            Console.Write("Finish deleting data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                    case 6:
                                        while (true)
                                        {
                                            Console.Write("Insert row id for deleting: ");
                                            strId = Console.ReadLine();
                                            if (!int.TryParse(strId, out id))
                                            {
                                                Console.WriteLine("It's incorrect value of id");
                                                continue;
                                            }
                                            else if (!await readerController.CheckPKValueAsync(id))
                                            {
                                                Console.WriteLine("Table don't have row with that id!");
                                                continue;
                                            }

                                            await readerController.DeleteDataAsync(id);

                                            Console.Write("Finish deleting data? ");
                                            if (Console.ReadLine()?.ToLower() == "y")
                                                break;
                                            Console.WriteLine();
                                        }
                                        break;
                                }
                            }
                            break;
                            #endregion
                        case 4:
                            return;
                        default:
                            Console.WriteLine("There are no such menu item!");
                            break;
                    }
                }
                break;
            default:
                Console.WriteLine("There are no such menu item!");
                break;
        }
    }
}
catch (Exception SqlEx)
{
    Console.WriteLine(SqlEx.Message);
}

int ChooseTable()
{
    Console.WriteLine("\n1. Author");
    Console.WriteLine("2. Author_Book");
    Console.WriteLine("3. Book");
    Console.WriteLine("4. Library");
    Console.WriteLine("5. Person");
    Console.WriteLine("6. Reader");
    Console.WriteLine("7. Exit");
    Console.Write("Choose table: ");
    if (!int.TryParse(Console.ReadLine(), out int item11))
        throw new ArgumentException("Invalid menu item!");

    return item11;
}

bool CheckDateString(string date)
{
    Regex validateDateRegex = new Regex("^[0-9]{4}\\.[0-9]{1,2}\\.[0-9]{1,2}$");
    return validateDateRegex.IsMatch(date);
}
