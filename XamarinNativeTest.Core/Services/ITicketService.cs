using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinNativeTest.Core.Services
{
    public interface ITicketService
    {
        List<TicketModel> GetAllTickets();
        void AddTicketToJson(TicketModel ticketModel);
        List<TicketModel> GetFiltredList(string searchTitle);
    }
}
