namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Start av programmet ===");

            try
            {
                Console.WriteLine("Försöker läsa fil och räkna...");
                var path = Path.Combine(AppContext.BaseDirectory, "numbers.txt");
                var result = ProcessFile(path);

                Console.WriteLine($"\nResultat: {result}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Filen hittades inte: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Formatfel: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Kan inte dividera med noll: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ogiltigt argument: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Okänt fel: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Cleanup: Logging avslutat anrop.");
            }

            Console.WriteLine("Programmet avslutas normalt.");
        }

        static double ProcessFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("Filnamn får inte vara tomt eller null.", nameof(fileName));
            }

            using (var reader = new StreamReader(fileName))
            {
                string? line = reader.ReadLine();
                if (line == null)
                {
                    throw new InvalidOperationException("Filen är tom.");
                }

                int number = int.Parse(line.Trim());

                if (number == 0)
                {
                    throw new DivideByZeroException("Kan inte dividera 100 med 0.");
                }

                return 100.0 / number;
            }
        }
    }
}