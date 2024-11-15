namespace comp2129_group_project.Managers
{
    public class FileManager
    {
        // Readonly file path strings to be used internally
        private static readonly string _projectDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
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

        // Gets a file based on name passed from constants
        // or as specified
        public string GetPath(string fileName)
        {
            try
            {
                string path = fileName switch
                {
                    "customers" => _customersFile,
                    "flights" => _flightsFile,
                    "bookings" => _bookingsFile,
                    _ => "",
                };

                return path;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void AppendFile(string fileName, string content)
        {
            try
            {
                string path = GetPath(fileName);

                File.AppendAllText(path, content + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string[] ReadFile(string fileName)
        {
            try
            {
                string path = GetPath(fileName);

                string[] temp = File.ReadAllLines(path);

                // Remove new lines when reading file
                string[] contents = temp.Where(x => x != Environment.NewLine).ToArray();

                return contents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
