namespace GreatPractic;//Переименовать неймспейс

public class ColumnSelection(string columnSelectoin,string[] selection)// может осавить чисто методы // добавить описание классакм и методам с помощью summary
{
    public string [] ColumnSelectoin {get;} = CheckInputColumnSelection(columnSelectoin, selection);
    
    private static string [] CheckInputColumnSelection(string columnSelectoin,string[] selectoin)
    {
        string [] columnSelectoinArray = columnSelectoin.Split(',');
        try
        {
            foreach (var s in columnSelectoinArray)
            {
                if (s == null)
                {
                    throw new Exception("Вы должны выбрать столбцы либо написать *.");
                }
                if (!selectoin.Contains(s) && columnSelectoinArray[0] != "*")
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
        return columnSelectoinArray;
    }
}
