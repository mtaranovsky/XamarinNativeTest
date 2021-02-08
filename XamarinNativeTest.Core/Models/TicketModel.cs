using MvvmCross.Platform.UI;

namespace XamarinNativeTest.Core.Services
{
    public class TicketModel
    {
        public int Id { get; set; }
        public string ProblemName { get; set; }
        public MvxColor Color { get; set; }
        public int ColorARGB { get; set; }
    }
}
