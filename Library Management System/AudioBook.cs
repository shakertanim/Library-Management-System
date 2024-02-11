namespace Library;

public class AudioBook : IBook
{
    public string bookName;
    public string bookType = "AudioBook";
    public string bookLocation = "Web";
    public string found;

    public AudioBook(string bookName, string bookType, string bookLocation)
    {
        this.bookName = bookName;
        this.bookType = bookType;
        this.bookLocation = bookLocation;
        this.found = "no";
    }

    public AudioBook()
    {
        
    }
    public void MarkAsBorrowed(string bookname, string findOrBorrow)
    {
        if (this.bookName == bookname && findOrBorrow == "Borrow")
        {
            Console.WriteLine($"Please find the {this.bookType} download link : https://ebook.ebookhouse.edu/elibrary/{this.bookName}.pub?{this.bookType}%{this.bookLocation}");
            
        }
    }

    public void MarkAsReturned()
    {
        
    }

    public string GetLocation()
    {
        return this.bookLocation;
    }
    public string findIt(AudioBook findTheEbook, string searchName)
    {
        if (findTheEbook.bookName == searchName)
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