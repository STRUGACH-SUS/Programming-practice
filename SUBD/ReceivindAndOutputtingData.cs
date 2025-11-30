namespace GreatPractic;//Переименовать неймспейс // добавить описание классакм и методам с помощью summary

public class ReceivindAndOutputtingData// может осавить чисто методы
{
    public static void PrepareText(string pathToFile, int[] pagination, string [] columnSelectoin, string divingSymbol)
    {
        var heading = (File.ReadLines(pathToFile).ToList()[0]).Split(divingSymbol);// по идее тут нормально все работает
        
        var lines = File.ReadLines(pathToFile).ToList()[pagination[0]..(pagination[1]+1)];// по идее тут нормально все работает
        
        string [][] g = lines.Select(line => line.Split(divingSymbol)).ToArray();// Точно ли массив выгоднее
        
        List<int> headingIndex = new List<int>();// точно ли выгодно
        for (int i = 0; i < columnSelectoin.Length; i++)
        {
            if (columnSelectoin[0] == "*")
            {
                for (int j = 0; j < heading.Length; j++)
                {
                    headingIndex.Add(j);
                }
                break;
            }
            headingIndex.Add(heading.IndexOf(columnSelectoin[i]));
        }
        
        foreach (var s in g)
        {
            for (int i = 0; i < headingIndex.Count; i++)
            {
                Console.Write(s[headingIndex[i]] + " ");
            }
            Console.WriteLine();
        }
    }
}
