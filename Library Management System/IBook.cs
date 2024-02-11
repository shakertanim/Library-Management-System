namespace Library;

public interface IBook
{
    public void MarkAsBorrowed(string bookname, string findOrBorrow);
    public void MarkAsReturned();
    public string GetLocation();
}