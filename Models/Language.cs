using System;

namespace Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ProjectLanguage> ProjectLanguages { get; set; } = new List<ProjectLanguage>();
    }
}
