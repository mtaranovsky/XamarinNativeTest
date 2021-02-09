using MvvmCross.Platform.UI;

namespace XamarinNativeTest.Core.Services
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string ProblemName { get; set; }
        public Enums.TicketPriority TicketPriority { get; set; }

        public TicketModel() { }

        public TicketModel(int id, string problem, Enums.TicketPriority ticketPriority)
        {
            Id = id;
            ProblemName = problem;
            TicketPriority = ticketPriority;
        } 
    }
}
