using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace Common.Windows;


internal static partial class PackageHelpers
{

    /// <summary>
    /// Check if a protocol was declared in Package.appxmanifest
    /// </summary>
    /// <param name="scheme">Name of the protocol</param>
    /// <returns></returns>
    public static bool IsUriProtocolDeclared(string scheme)
    {

        var docPath = Path.Combine(global::Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "AppxManifest.xml");
        var doc = XDocument.Load(docPath, LoadOptions.None);
        var reader = doc.CreateReader();
        var namespaceManager = new XmlNamespaceManager(reader.NameTable);
        namespaceManager.AddNamespace("x", "http://schemas.microsoft.com/appx/manifest/foundation/windows10");
        namespaceManager.AddNamespace("uap", "http://schemas.microsoft.com/appx/manifest/uap/windows10");

        // Check if the protocol was declared
        var decl = doc.Root?.XPathSelectElements($"//uap:Extension[@Category='windows.protocol']/uap:Protocol[@Name='{scheme}']", namespaceManager);

        return decl != null && decl.Any();
    }

}
