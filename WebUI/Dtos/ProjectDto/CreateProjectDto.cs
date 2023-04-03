using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.ProjectDto
{
    public class CreateProjectDto
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ProjectImage { get; set; }
    }
}
