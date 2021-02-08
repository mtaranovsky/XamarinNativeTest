using XamarinNativeTest.Core.Services;

namespace XamarinNativeTest.Droid
{
    public class TicketsJsonLocationService : ITicketJsonLoccationServices
    {
        public string GetJsonFolder()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }
    }
}