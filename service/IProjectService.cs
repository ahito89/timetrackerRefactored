using System;
using System.Collections.Generic;
using data;

namespace service
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjects();
        Project GetProject(long id);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(long id);
    }
}
