namespace Library;

public class Exit
{
    public void exit(int exit)
    {
        try
        {
            System.Environment.Exit(exit);
        }
        catch (Exception e)
        {
            Console.WriteLine("GoodBye.....!!!!");
        }
    }
}