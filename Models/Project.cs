using Models.Enums;
using System;

namespace Models
{
    public class Project : BaseProject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public EngineTypes Engine { get; set; }
        public ICollection<ProjectLanguage> ProjectLanguages { get; set; }
    }
}
