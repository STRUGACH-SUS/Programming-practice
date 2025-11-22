namespace GreatPractic;

public class CheckColumnSelection
{
    private string [] ColumnSelectoin {get; set;}
    private string [] Selectoin {get; set;}
    
    public CheckColumnSelection(string columnSelectoin, string[] selectoin)
    {
        ColumnSelectoin = columnSelectoin.Split(',');
        Selectoin = selectoin;
        CheckInputColumnSelection(ColumnSelectoin, Selectoin);
    }

    private void CheckInputColumnSelection(string[] columnSelectoin,string[] selectoin)
    {
        try
        {
            foreach (var s in columnSelectoin)
            {
                if (s == null)
                {
                    throw new Exception("Вы должны выбрать столбцы либо написать *.");
                }
                if (!selectoin.Contains(s) && columnSelectoin[0] != "*")
                {
                    throw new Exception("Неправильно указаны столбцы из файла.");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }
}