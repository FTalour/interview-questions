using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Folders
{
    class Folders
    {
        static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            XDocument xDocument = XDocument.Parse(xml);
            foreach (var name in xDocument.Descendants("folder").Select(xele => xele.Attribute("name").Value).Where(ele => ele.StartsWith(startingLetter.ToString())))
            {
                yield return name;
            }
        }

        static void Main(string[] args)
        {
            string xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"uninstall information\" />" +
                    "</folder>" +
                    "<folder name=\"users\" />" +
                "</folder>";

            foreach (string name in Folders.FolderNames(xml, 'u'))
                Console.WriteLine(name);
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
