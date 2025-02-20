using log4net;
using log4net.Config;
using System.Reflection;

namespace ExceptionHandling
{
    internal class Program
    {
        private static readonly ILog log 
            = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType ?? typeof(Program));

        static void Main(string[] args)
        {
            // Configure Log4Net
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            Console.WriteLine("Hello, World!");
            string filePath = "number.txt";
            ReadAndDivide(filePath);
        }
        static void ReadAndDivide(string filePath)
        {
            try
            {
                log.Info($"Attempting to read file: {filePath}");

                // Read the number from the file
                string content = File.ReadAllText(filePath);
                int number = int.Parse(content.Trim()); // May throw FormatException

                // Divide 100 by the number
                int result = 100 / number; // May throw DivideByZeroException

                Console.WriteLine($"100 divided by {number} is {result}");
                log.Info($"Calculation successful: 100 / {number} = {result}");
            }
            catch (FileNotFoundException ex)
            {
                log.Error("File not found.", ex);
                Console.WriteLine("Error: The file was not found.");
            }
            catch (FormatException ex)
            {
                //log.Error("Invalid number format.", ex);
                //Console.WriteLine("Error: The file does not contain a valid number.");
                throw new NumberFormatException("Invalid number format encountered in input file.", ex);
            }
            catch (DivideByZeroException ex)
            {
                log.Error("Attempted division by zero.", ex);
                Console.WriteLine("Error: Cannot divide by zero.");
            }
            catch (IOException ex)
            {
                log.Error("File access error.", ex);
                Console.WriteLine($"File access error: {ex.Message}");
            }
            catch (Exception ex)
            {
                log.Fatal("An unexpected error occurred.", ex);
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                log.Info("Operation complete.");
                Console.WriteLine("Operation complete.");
            }
        }
    }
}
