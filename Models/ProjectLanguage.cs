using Models;
using System;

namespace Models
{
    public class ProjectLanguage
    {
        public int ProjectId { get; set; }
        public int LanguageId { get; set; }
        public Project? Project { get; set; }
        public Language? Language { get; set; }
    }
}
