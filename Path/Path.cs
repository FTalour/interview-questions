using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path
{
    public class Path
    {
        public string CurrentPath { get; private set; }

        public Path(string path)
        {
            this.CurrentPath = path;
        }

        public void Cd(string newPath)
        {
            // Use absolute paths
            if (newPath.StartsWith("/"))
                this.CurrentPath = newPath;
            // Use relative paths
            else if (newPath.StartsWith(".."))
            {
                while (newPath.StartsWith("../"))
                {
                    GoToParentDirectory();
                    newPath = newPath.Substring(3);
                }
                // Selecting parent directories
                if (newPath == "..")
                {
                    GoToParentDirectory();
                }
                // Selecting complex paths
                else
                {
                    this.CurrentPath = this.CurrentPath + "/" + newPath;
                }
            }
            // Selecting child directories
            else
            {
                this.CurrentPath = this.CurrentPath + "/" + newPath;
            }
        }

        public void GoToParentDirectory()
        {
            if (this.CurrentPath == "/")
                return;

            while (!this.CurrentPath.EndsWith("/"))
            {
                this.CurrentPath = this.CurrentPath.Remove(this.CurrentPath.Length - 1);
            }
            this.CurrentPath = this.CurrentPath.Remove(this.CurrentPath.Length - 1);
        }


        public static void Main(string[] args)
        {
            Path path = new Path("/a/b/c/d");
            path.Cd("../x");
            Console.WriteLine(path.CurrentPath);
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
