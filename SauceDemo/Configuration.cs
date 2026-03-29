using Microsoft.Extensions.Configuration;

namespace SauceDemo;

public class Configuration
{
    public static string BrowserType { get; set; }
    public static string SiteUrl { get; set; }

    static Configuration() => Init();
    
    private static void Init()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        BrowserType = config["BrowserType"] ?? "Chrome";
        SiteUrl = config["SiteUrl"] ?? string.Empty;    
    }
}