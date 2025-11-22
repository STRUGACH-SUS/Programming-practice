using System.Text;

namespace GreatPractic
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("""Введите путь до папки с файлами (пример: C:\Users\htcbe\Downloads\test_data ): """);
            string pathToFolder = Console.ReadLine()!;

            Console.WriteLine($"Введите имя нужного файла (пример: contractors.csv ): ");
            foreach (var s in Directory.GetFiles(pathToFolder))
            {
                if (Path.GetExtension(s) == ".csv" || Path.GetExtension(s) == ".tsv")
                {
                    Console.WriteLine("- " + Path.GetFileName(s));
                }
            }
            string nameOfFile = Console.ReadLine()!;
            PathToFile pathToFile = new PathToFile(pathToFolder, nameOfFile);
            

            Console.WriteLine("Введите начальную и конечную строчку (пример: 10,20 ): ");
            int[] pagination = (Console.ReadLine()!.Split(',')).Select(int.Parse).ToArray(); //Дописать проверку на последние строки
            Pagination pagination1 = new Pagination(pagination);


            Console.WriteLine("Введите названия столбцов которые нужно получить (пример: Id,Name ). Введя * вы выбираете все столбцы : ");
            string divingSymbol= (Path.GetExtension(Path.Combine(pathToFolder, nameOfFile)) == ".csv") ? ";" : "\t";
            string[] selection = File.ReadLines(pathToFile.FullPathToFile).ToList()[0].Split(divingSymbol);
            foreach (var s in selection)
            {
                Console.WriteLine("- " + s);
            }
            string columnSelectoin = Console.ReadLine()!; //Проверки сюда нужно
            ColumnSelection columnSelection = new ColumnSelection(columnSelectoin, selection);
            
            ReceivindAndOutputtingData.PrepareText(pathToFile.FullPathToFile,pagination1.PaginationForFile,columnSelection.ColumnSelectoin,divingSymbol);
        }
    }
}