namespace GreatPractic;

public class CustomArguments
{
    private string PathToFile {get; set;}
    private int[] Pagination {get; set;} = new int[2];

    private string [] ColumnSelectoin {get; set;}
    
    public CustomArguments(string pathToFolder, string nameOfFile, int[] pagination, string columnSelectoin)
    {
        PathToFile = Path.GetFullPath(Path.Combine(pathToFolder, nameOfFile));
        Pagination = pagination;
        ColumnSelectoin = columnSelectoin.Split(',');
        PrepareText(PathToFile, Pagination, ColumnSelectoin);
    }
    
    
    private static void PrepareText(string pathToFile, int[] pagination, string [] columnSelectoin)
    {
        string divingSymbol = (Path.GetExtension(pathToFile)==".csv") ? ";" : "\t";
        
        var heading = (File.ReadLines(pathToFile).ToList()[0]).Split(divingSymbol);
        
        var lines = File.ReadLines(pathToFile).ToList()[pagination[0]..(pagination[1]+1)];
        
        string [][] g = lines.Select(line => line.Split(divingSymbol)).ToArray();
        
        List<int> headingIndex = new List<int>();
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