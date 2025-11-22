namespace GreatPractic;

public class Pagination(int[] pagination)
{
    public int[] PaginationForFile {get; set;} = CheckInputPagination(pagination);

    private static int[] CheckInputPagination(int[] pagination)
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
        return pagination;
    }
}