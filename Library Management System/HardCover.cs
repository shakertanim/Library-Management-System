using System.Net;

namespace Library;

public class HardCover : IBook
{
    public string bookName;
    public string bookType = "HardCover";
    public string bookLocation = "Library";
    public bool isBorrowed = false;
    public string found;

    
    
    
    public HardCover(string bookName, string bookType, string bookLocation, bool isBorrowed)
    {
        this.bookName = bookName;
        this.bookType = bookType;
        this.bookLocation = bookLocation;
        this.isBorrowed = isBorrowed;
        this.found = "no";
    }

    public HardCover()
    {
        
    }
    
    public void MarkAsBorrowed(string bookname, string findOrBorrow)
    {
        if (this.bookName == bookname && findOrBorrow == "Borrow" && this.bookLocation!="Client")
        {
            this.bookLocation = "Client";
            this.isBorrowed = true;
            Console.WriteLine($"Book {this.bookName}'s status changed to Borrowed.");
        }
        else if (this.bookName == bookname && findOrBorrow == "Borrow" && this.bookLocation == "Client")
        {
            Console.WriteLine($"The book {bookname} is not available to {findOrBorrow}. Its already in another {this.bookLocation} end.");
        }
        else if (findOrBorrow == "Return")
        {
            MarkAsReturned();
        }
    }

    public void MarkAsReturned()
    {
        this.bookLocation = "Library";
        this.isBorrowed = false;
    }

    public string GetLocation()
    {
        return this.bookLocation;
    }

    public string findIt(HardCover findHardCoverBook, string searchName)
    {
        if (findHardCoverBook.bookName == searchName)
        {
            this.found = "yes";
        }
        else
        {
            this.found = "no";
        }
        return this.found;
    }
}