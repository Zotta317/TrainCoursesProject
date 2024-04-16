using trainTicketApp.DTOs;
using trainTicketApp.Model;
using trainTicketApp.Repository;

namespace trainTicketApp.Service
{
    public interface ITicketService
    {
        List<TicketGetDTO> GetTickets(Guid userID);
        Task<Ticket> AddTicket(Guid courseID, Guid userId);
    }
    public class TicketService : ITicketService
    {
        public TicketRepository _ticketRepository { get; set; }

        public TicketService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public List<TicketGetDTO> GetTickets(Guid userID)
        {
            return _ticketRepository.GetTickets(userID);
        }

        public async Task<Ticket> AddTicket(Guid courseID, Guid userId)
        {
            return await _ticketRepository.AddTicket(courseID, userId);
        }
    }

}
