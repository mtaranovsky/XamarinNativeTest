using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinNativeTest.Core.Services
{
    public interface ITicketService
    {
        List<TicketModel> ConvertJsonToList();
        void AddTicketToJson(TicketModel ticketModel);
        string JsonLocation();
        List<TicketModel> GetFiltredList(string searchTitle);
    }
}
