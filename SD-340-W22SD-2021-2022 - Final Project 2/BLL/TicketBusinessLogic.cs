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

        public async void CreateTicket(Ticket ticket)
        {
            repo.Create(ticket);
            repo.Save();
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

        public Ticket UpdateTicketToComplete(int ticketId, bool isComplete)
        {
            List<Ticket> tickets = repo.GetList(ticket => !ticket.Completed).ToList();
            Ticket ticket = tickets.First(ticket => ticket.Id == ticketId);
            repo.Save();
            return repo.Update(ticket);
        }

        public Ticket UpdateTicketToIncomplete(int ticketId, bool isComplete)
        {
            List<Ticket> tickets = repo.GetList(ticket => ticket.Completed).ToList();
            Ticket ticket = tickets.First(ticket => ticket.Id == ticketId);
            return repo.Update(ticket);
        }

        public Ticket UpdateTicketRequiredHours(int ticketId, int hours)
        {
            List<Ticket> tickets = repo.GetAll().ToList();
            Ticket ticket = tickets.First(ticket => ticket.Id == ticketId);
            ticket.Hours = hours;
            return repo.Update(ticket);
        }

        public async Task<Ticket> UpdateTicketAddWatcher(int ticketId)
        {

            ApplicationUser currUser = await _userManager.FindByNameAsync(Thread.CurrentThread.Name);
            Ticket ticket = repo.Get(ticketId);
            ticket.TaskWatchers.Add(currUser);
            return repo.Update(ticket);
        }

        public async Task<Ticket> UpdateTicketRemoveWatcher(int ticketId)
        {

            ApplicationUser currUser = await _userManager.FindByNameAsync(Thread.CurrentThread.Name);
            Ticket ticket = repo.Get(ticketId);
            ticket.TaskWatchers.Remove(currUser);
            return repo.Update(ticket);
        }

    }
}
