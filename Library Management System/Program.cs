using System;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Net;
using System.IO;


namespace Library;

public class LibraryManager
{
    public void borrowOrReturn(string findBook, string bookType, OperationOnBooks books, IBook booksOperation, string findOrBorrow,HardCover hardCover, Ebook eBook,AudioBook audioBook)
    {
        Console.Write($"Book Name to {findOrBorrow} : ");
        findBook = Console.ReadLine();
        Console.Write("Book Type : \n 1. EBook \n 2. HardCover \n 3. AudioBook: \n Choose:");
        bookType = books.chooseBookType(bookType);
        booksOperation = books.findBooks(findBook, bookType, findOrBorrow);
        if (bookType == "HardCover" )
        {
            hardCover = (HardCover)booksOperation;
            hardCover.MarkAsBorrowed(findBook,findOrBorrow);
        }
        else if (bookType == "EBook" && findOrBorrow=="Borrow")
        {
            eBook = (Ebook)booksOperation;
            eBook.MarkAsBorrowed(findBook,findOrBorrow);
        }
        else if (bookType == "AudioBook" && findOrBorrow=="Borrow")
        {
            audioBook = (AudioBook)booksOperation;
            audioBook.MarkAsBorrowed(findBook,findOrBorrow);
        }
        else if ((bookType == "EBook" || bookType == "AudioBook") && findOrBorrow == "Return")
        {
            Console.WriteLine("You cannot return AudioBook and eBook.");
        }
        else if (booksOperation == null)
        {
            Console.WriteLine(findBook+ " was not found.");
        }
    }
    public int menu(bool loop, string menuItemInput, int menuItem)
    {
        while (loop)
        {
            Console.Write(
                "Library Menu : \n 0. Exit \n 1. Add a new book \n 2. Find a book \n 3. Borrow \n 4. Return \n Choose : ");
            menuItemInput = Console.ReadLine();
            try
            {
                menuItem = Convert.ToInt32(menuItemInput);
                loop = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("This operation is not supported, please try again");
                loop = true;
                //throw;
            }
        }

        return menuItem;
    }

    public static void Main(string[] args)
    {
        HardCover hardCover = new HardCover();
        Ebook eBook = new Ebook();
        AudioBook audioBook = new AudioBook();
        string continueOrExit;
        LibraryManager menu = new LibraryManager();
        OperationOnBooks books = new OperationOnBooks();
        Exit exit = new Exit();
        int menuItem=0;
        bool loop=true;
        string menuItemInput="";
        string findBook="";
        string bookType=null;
        string findOrBorrow = null;
        IBook booksOperation = null;
        menuItem = menu.menu(loop,menuItemInput,menuItem);

        
        while (menuItem >=0 && menuItem<=4 && loop)
        {
            try
            {
                switch (menuItem)
                {
                    case 0 :
                        exit.exit(menuItem);
                        break;
                    case 1:
                        books.AddBooks();
                        Console.Write("Do you want to continue? : (Y or any other character to exit) :");
                        continueOrExit = Console.ReadLine();
                        if (continueOrExit == "y" || continueOrExit == "Y")
                        {
                            menuItem = menu.menu(loop,menuItemInput,menuItem);
                        }
                        else
                        {
                            loop = false;
                        }
                        break;
                    case 2:
                        Console.Write("Book Name to Find : ");
                        findBook = Console.ReadLine();
                        findOrBorrow = "Find";
                        books.findBooks(findBook,null, findOrBorrow);
                        Console.Write("Do you want to continue? : (Y or any other character to exit) :");
                        continueOrExit = Console.ReadLine();
                        if (continueOrExit == "y" || continueOrExit == "Y")
                        {
                            menuItem = menu.menu(loop,menuItemInput,menuItem);
                        }
                        else
                        {
                            loop = false;
                        }
                        break;
                    case 3:
                        findOrBorrow = "Borrow";
                        menu.borrowOrReturn(findBook, bookType, books, booksOperation, findOrBorrow, hardCover, eBook, audioBook);
                        Console.Write("Do you want to continue? : (Y or any other character to exit) :");
                        continueOrExit = Console.ReadLine();
                        if (continueOrExit == "y" || continueOrExit == "Y")
                        {
                            menuItem = menu.menu(loop,menuItemInput,menuItem);
                        }
                        else
                        {
                            loop = false;
                        }
                        break;
                    case 4:
                        findOrBorrow = "Return";
                        menu.borrowOrReturn(findBook, bookType, books, booksOperation, findOrBorrow, hardCover, eBook, audioBook);
                        Console.Write("Do you want to continue? : (Y or any other character to exit) :");
                        continueOrExit = Console.ReadLine();
                        if (continueOrExit == "y" || continueOrExit == "Y")
                        {
                            menuItem = menu.menu(loop,menuItemInput,menuItem);
                        }
                        else
                        {
                            loop = false;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"This operation is not supported, Library stock might be empty or you are trying to borrow or return books on empty stock. Please add some book first.");
                loop = true;
                menuItem = 1;
            }
        }
        
        
        
    }
}

