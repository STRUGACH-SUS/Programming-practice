namespace GreatPractic;

public class CheckPathToFile
{
    private string PathToFile {get; set;}

    public CheckPathToFile(string pathToFolder, string nameOfFile)
    {
        PathToFile = Path.Combine(pathToFolder, nameOfFile);
        CheckInputPathToFile(PathToFile);
    }
    
    private static void CheckInputPathToFile(string pathToFile)
    {
        try
        {
            if (pathToFile == null)
            {
                throw new Exception("Имя файла не может быть пустым.");
            }
            
            if (!File.Exists(pathToFile))
            {
                throw new Exception("Файл не существует или неправильно указан путь к нему.");
            }

            if (Path.GetExtension(pathToFile) != ".csv" && Path.GetExtension(pathToFile) != ".tsv")
            {
                throw new Exception("Можно указывать файлы с расширениями .csv и .tsv.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }
}