using comp2129_group_project.Entities;
using static comp2129_group_project.Entities.Constants;

namespace comp2129_group_project.Managers
{
    public class FileManager
    {
        // Readonly file path strings to be used internally
        private static readonly string _projectDirectory = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
        private static readonly string _fileFolder = Path.Combine(_projectDirectory, "TextFiles");
        private readonly string _customersFile = Path.Combine(_fileFolder, "customers.txt");
        private readonly string _flightsFile = Path.Combine(_fileFolder, "flights.txt");
        private readonly string _bookingsFile = Path.Combine(_fileFolder, "bookings.txt");

        public void CreateFiles()
        {
            try
            {
                if (!Directory.Exists(_projectDirectory))
                {
                    throw new DirectoryNotFoundException("Project directory not found");
                }

                if (!Directory.Exists(_fileFolder))
                {
                    Directory.CreateDirectory(_fileFolder);

                    FileStream f1 = File.Create(_customersFile);
                    f1.Close();

                    FileStream f2 = File.Create(_flightsFile);
                    f2.Close();

                    FileStream f3 = File.Create(_bookingsFile);
                    f3.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        // Clear all txt files for debugging
        // May be removed once we are done
        public void ClearAllTxtFiles()
        {
            try
            {
                if (!Directory.Exists(_fileFolder))
                {
                    throw new DirectoryNotFoundException("Text files folder not found");
                }

                File.WriteAllText(_customersFile, "");
                File.WriteAllText(_flightsFile, "");
                File.WriteAllText(_bookingsFile, "");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        // Gets a file based on name passed from constants
        // or as specified
        private string GetPath(string fileName)
        {
            try
            {
                string path = fileName switch
                {
                    CUSTOMERS_FILE => _customersFile,
                    FLIGHTS_FILE => _flightsFile,
                    BOOKINGS_FILE => _bookingsFile,
                    _ => "",
                };

                return path;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                throw;
            }
        }


        public void DeleteFile(string fileName)
        {
            try
            {
                string path = GetPath(fileName);

                File.Delete(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AppendFile(string fileName, string content)
        {
            try
            {
                string path = GetPath(fileName);

                // Using pipe '|' as a separator of elements 
                File.AppendAllText(path, content + "|");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public string[] ReadFile(string fileName)
        {
            try
            {
                string path = GetPath(fileName);

                string temp = File.ReadAllText(path);

                // Remove separator when reading file
                string[] contents = temp.Split('|');

                return contents;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                throw;
            }
        }
    }
}
