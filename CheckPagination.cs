namespace GreatPractic;

public class CheckPagination
{
    private int[] Pagination {get; set;} = new int[2];
    
    public CheckPagination(int[] pagination)
    {
        Pagination = pagination;
        CheckInputPagination(Pagination);
    }

    private void CheckInputPagination(int[] pagination)
    {
        try
        {
            
            if (!(pagination[0] > 0 && pagination[1] > 0 && pagination[0] < pagination[1]))
            {
                throw new Exception("Неправильно указан промежуток вывода строк.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }
}