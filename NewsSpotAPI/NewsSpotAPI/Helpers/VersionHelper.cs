namespace NewsSpotAPI.Helpers;

public class VersionHelper
{
    public static string GetProductionVersion(string[] versions)
{
    string productionVersion = "";
    foreach (string version in versions)
    {
        if (!version.Contains("-"))
        {
            productionVersion = version;
            break;
        }
        else
        {
            string[] parts = version.Split('-');
            string baseVersion = parts[0];
            if (productionVersion == "" || baseVersion.CompareTo(productionVersion) > 0)
            {
                productionVersion = baseVersion;
            }
        }
    }
    return productionVersion;
}

}
