using Microsoft.AspNetCore.Identity;
using SD_340_W22SD_2021_2022___Final_Project_2.DAL;
using SD_340_W22SD_2021_2022___Final_Project_2.Models;

namespace SD_340_W22SD_2021_2022___Final_Project_2.BLL
{
    public class TicketBusinessLogic
    {
        private IRepository<Ticket> repo;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public TicketBusinessLogic(IRepository<Ticket> repo, 
            UserManager<ApplicationUser> userManager)
        {
            this.repo = repo;
            this._userManager = userManager;
            
        }

        public void CreateTicket(Ticket ticket)
        {
            repo.Create(ticket);
            repo.Save();
        }

        public Ticket GetTicket(int id)
        {
            return repo.Get(id);
        }

        public List<Ticket> GetTicketList(int projectId)
        {
            return repo.GetList(ticket => ticket.ProjectId == projectId).ToList();
        }

        // Needs project repo
        public List<Ticket> GetCompletedTickets(int projectid)
        {
            return repo.GetList(project => project.ProjectId == projectid).ToList();
        }

        //public void UpdateTicketToComplete(Ticket entity)
        //{
        //    repo.Update(entity);
        //    repo.Save();
        //}

        //public void UpdateTicketToIncomplete(Ticket entity)
        //{
        //    repo.Update(entity);
        //    repo.Save();
        //}

        public void UpdateTicketStatus(Ticket entity)
        {
            entity.Completed = !entity.Completed;
            repo.Update(entity);
            repo.Save();
        }

        public void UpdateTicketRequiredHours(Ticket entity, int hours)
        {
            entity.Hours = hours;
            repo.Update(entity);
            repo.Save();
        }

        public async void UpdateTicketAddWatcher(Ticket entity, ApplicationUser user)
        {
            entity.TaskWatchers.Add(user);
            repo.Update(entity);
            repo.Save();
        }

        public async void UpdateTicketRemoveWatcher(Ticket entity, ApplicationUser user)
        {

            entity.TaskWatchers.Remove(user);
            repo.Update(entity);
            repo.Save();
        }

    }
}
