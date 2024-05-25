
namespace ConfigurationReaderDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string applicationName = "SERVICE-B";
            string connectionString = "Server=localhost;Database=ConfigurationReaderDb;User=sa;Password=230401yagmur;TrustServerCertificate=True;";
            int refreshTimerIntervalInMs = 6000;

            var configurationReader = new ConfigurationReader.ConfigurationReader(applicationName, connectionString, refreshTimerIntervalInMs);

            Console.WriteLine("Fetching configuration values...");

            while (true)
            {
                try
                {
                    var maxItem = configurationReader.GetValue<int>("MaxItemCount");
                    Console.WriteLine($"max item: {maxItem}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                await Task.Delay(2000); // 2 saniye bekle
            }
        }
    }
}