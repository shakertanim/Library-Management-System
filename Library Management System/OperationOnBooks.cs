using System.Threading.Channels;

namespace Library;

public class OperationOnBooks
{
    public List<IBook> libraryBooks = new List<IBook>();


    public string chooseBookType(string bookType)
    {
        string input;
        int choose;
        bool loop = true;
        while (loop)
        {
            input = Console.ReadLine();
            try
            {
                choose = Convert.ToInt32(input);

                if (choose == 1)
                {
                    bookType = "EBook";
                    loop = false;
                }
                else if (choose == 2)
                {
                    bookType = "HardCover";
                    loop = false;
                }
                else if (choose == 3)
                {
                    bookType = "AudioBook";
                    loop = false;
                }
                else
                {
                    Console.WriteLine("Invalid input of integer. Valid inputs are 1 to 3. Please Try Again!!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input of integer. Valid inputs are 1 to 3. Please Try Again!!!!");
            }
        }

        return bookType;
    } 
    public void AddBooks()
    {
        
        string bookName;
        string bookType=null;
        bool isBorrowed = false;
        string location;
       
        IBook newBook = null;
        Console.Write("Book Name : ");
        bookName = Console.ReadLine();
        Console.Write("Book Type : \n 1. EBook \n 2. HardCover \n 3. AudioBook: \n Choose:");
        bookType = chooseBookType(bookType);
        if (bookType == "HardCover")
        {
            location = "Library";
            newBook = new HardCover(bookName,bookType,location,false);
        }
        else if(bookType == "EBook") 
        {
            location = "Web";
            newBook = new Ebook(bookName,bookType,location);
        }
        else if (bookType == "AudioBook")
        {
            location = "Web";
            newBook = new AudioBook(bookName,bookType,location);
        }
        else
        {
            newBook = null;
        }
        
        if (newBook != null)
        {
            libraryBooks.Add(newBook);
        }
    }

    public IBook findBooks(string bookName, string bookActualType, string findOrBorrow)
    {
        string found="no";
        bool isBorrowed = false;
        string location = "Web";
        string bookType = "None";
        int count = 0;
        HardCover findTheHardCover = new HardCover();
        Ebook findTheEbook = new Ebook();
        AudioBook findTheAudioBook = new AudioBook();
        IBook borrowBook = null;
        foreach (IBook ibook in libraryBooks)
        {
            //Console.WriteLine(ibook.GetType());
            if (ibook.GetType() == typeof(HardCover))
            {
                HardCover findBook = ibook as HardCover;
                isBorrowed = findBook.isBorrowed;
                location = findBook.bookLocation;
                bookType = findBook.bookType;
                found = findTheHardCover.findIt(findBook,bookName);
                //Console.WriteLine(found +" "+location);
                borrowBook = (IBook)findBook;
            }
            else if (ibook.GetType() == typeof(Ebook))
            {
                Ebook findBook = ibook as Ebook;
                location = findBook.bookLocation;
                bookType = findBook.bookType;
                found = findTheEbook.findIt(findBook, bookName);
                borrowBook = (IBook)findBook;
            }
            else if (ibook.GetType() == typeof(AudioBook))
            {
                AudioBook findBook = ibook as AudioBook;
                location = findBook.bookLocation;
                bookType = findBook.bookType;
                found = findTheAudioBook.findIt(findBook, bookName);
                borrowBook = (IBook)findBook;
            }

            if (found == "yes" && bookType == bookActualType && location == "Web" && findOrBorrow == "Borrow")
            {
                break;
            }
            else if (found == "yes" && bookType == bookActualType && location == "Library" && findOrBorrow == "Borrow")
            {
                break;
            }
            if (found == "yes" && isBorrowed && location=="Client" && findOrBorrow!="Return")
            {
                Console.WriteLine("The "+bookType+" book "+ bookName +" is borrowed.");
                count += 1;
            }
            else if (found == "yes" && isBorrowed && location == "Client" && findOrBorrow == "Return")
            {
                Console.WriteLine("The "+bookType+" book "+ bookName +" is in process of return.");
                count += 1;
            }
            else if (found == "yes" && !isBorrowed && location == "Library" && findOrBorrow == "Return")
            {
                Console.WriteLine("The "+bookType+" book "+ bookName +" is already in the Library.");
                count += 1;
            }
            else if(found == "yes"&& !isBorrowed && location=="Library")
            {
                Console.WriteLine("The "+bookType+" book "+ bookName +" is available in the Library.");
                count += 1;
            }
            else if (found == "yes" && location == "Web" && bookActualType!="HardCover")
            {
                Console.WriteLine("The "+bookType+" "+ bookName +" is available to download from Web.");
                count += 1;
            }
        }
        
        
        if (found == "no" && count == 0 )
        {
            Console.WriteLine("The book "+bookName+" does not exist in the library");
        }
        else if (libraryBooks == null)
        {
            Console.WriteLine("Library stock is Empty. Please add some books first.");
            AddBooks();
        }

        findTheHardCover = null;
        findTheAudioBook = null;
        findTheEbook = null;
        return (borrowBook);
    }
}