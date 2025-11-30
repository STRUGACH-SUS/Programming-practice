using System.Text;

namespace GreatPractic//Переименовать неймспейс 
{
    public class Program// добавить описание классакм и методам с помощью summary
    {
        static void Main()
        {
            Console.WriteLine("""Введите путь до папки с файлами (пример: C:\Users\htcbe\Downloads\test_data ): """);
            string pathToFolder = Console.ReadLine()!;//Сделать отдельным калссом для принятий значений

            Console.WriteLine($"Введите имя нужного файла (пример: contractors.csv ): ");
            foreach (var s in Directory.GetFiles(pathToFolder))// сделать метод интерфейс под ттакую задачу
            {
                if (Path.GetExtension(s) == ".csv" || Path.GetExtension(s) == ".tsv")
                {
                    Console.WriteLine("- " + Path.GetFileName(s));// Стрринг билдер сюда надо
                }
            }
            string nameOfFile = Console.ReadLine()!;//Сделать отдельным калссом для принятий значений
            PathToFile pathToFile = new PathToFile(pathToFolder, nameOfFile);
            

            Console.WriteLine("Введите начальную и конечную строчку (пример: 10,20 ): ");
            int[] pagination = (Console.ReadLine()!.Split(',')).Select(int.Parse).ToArray(); //Дописать проверку на последние строки //Сделать отдельным калссом для принятий значений
            Pagination pagination1 = new Pagination(pagination);


            Console.WriteLine("Введите названия столбцов которые нужно получить (пример: Id,Name ). Введя * вы выбираете все столбцы : ");
            string divingSymbol= (Path.GetExtension(Path.Combine(pathToFolder, nameOfFile)) == ".csv") ? ";" : "\t";// сделать метод интерфейс под ттакую задачу
            string[] selection = File.ReadLines(pathToFile.FullPathToFile).ToList()[0].Split(divingSymbol);// сделать метод интерфейс под ттакую задачу
            foreach (var s in selection)// сделать метод интерфейс под ттакую задачу
            {
                Console.WriteLine("- " + s);
            }
            string columnSelectoin = Console.ReadLine()!; //Проверки сюда нужно //Сделать отдельным калссом для принятий значений
            ColumnSelection columnSelection = new ColumnSelection(columnSelectoin, selection);
            
            ReceivindAndOutputtingData.PrepareText(pathToFile.FullPathToFile,pagination1.PaginationForFile,columnSelection.ColumnSelectoin,divingSymbol);
        }
    }
}
