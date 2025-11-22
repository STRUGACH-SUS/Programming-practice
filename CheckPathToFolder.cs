using System.Reflection.Metadata;
using System;

namespace GreatPractic;

public class CheckPathToFolder
{
    private string PathToFolder {get; set;}

    public CheckPathToFolder(string pathToFolder)
    {
        PathToFolder = pathToFolder;
        CheckInputPathToFolder(PathToFolder);
    }
    
    private static void CheckInputPathToFolder(string pathToFolder)
    {
        try
        {
            if (pathToFolder == null)
            {
                throw new Exception("Путь к каталогу не может быть пустым.");
            }
            
            if (!Directory.Exists(pathToFolder))
            {
                throw new Exception("Католог не существует или неправильно указан путь к нему.");
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }
}