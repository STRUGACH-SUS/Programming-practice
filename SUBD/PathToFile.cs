namespace GreatPractic;//Переименовать неймспейс

public class PathToFile(string pathToFolder, string nameOfFile)// может осавить чисто методы // добавить описание классакм и методам с помощью summary
{
    public string FullPathToFile {get;} = CheckInputPathToFile(pathToFolder, nameOfFile);
    
    private static string CheckInputPathToFile(string pathToFolder,string nameOfFile)
    {
        string pathToFile = Path.Combine(pathToFolder, nameOfFile);
        try
        {
            if (!Directory.Exists(pathToFolder))
            {
                throw new Exception("Католог не существует или неправильно указан путь к нему.");
            }
            
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
        return pathToFile; 
    }
}
