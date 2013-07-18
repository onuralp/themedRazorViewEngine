using System;

namespace ThemedViewEngine.Entity
{
    public class Theme
    {
        public string Layout { get; set; }
        public string Name { get; set; }
        public string BasePath { get; set; }
        public string Path { get { return String.Format("~/{0}/{1}/",BasePath,Name); } }
        public Theme(string basePath, string name)
        {
            Name = name;
            BasePath = basePath;
        }
    }
}