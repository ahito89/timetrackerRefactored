using System.Collections.Generic;
using data;
using repository;

namespace service
{
    public class ProjectService : IProjectService
    {
        private IRepository<Project> projectRepository;
        public ProjectService(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public IEnumerable<Project> GetProjects()
        {
            return projectRepository.GetAll();
        }

        public Project GetProject(long id)
        {
            return projectRepository.Get(id);
        }

        public void CreateProject(Project project)
        {
            projectRepository.Create(project);
        }

        public void UpdateProject(Project project)
        {
            projectRepository.Update(project);
        }

        public void DeleteProject(long id)
        {
            Project project = projectRepository.Get(id);
            if (project != null)
            {
                projectRepository.Delete(project);
            }
        }
    }
}