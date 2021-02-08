using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace XamarinNativeTest.Core.Services
{
    class TicketService : ITicketService
    {
        private readonly string _ticketsJsonFolder;

        public TicketService(ITicketJsonLoccationServices service)
        {
            _ticketsJsonFolder = service.GetJsonFolder();
        }
        public List<TicketModel> ConvertJsonToList()
        {
            try
            {
                string JsonString = "";
                if (!File.Exists(JsonLocation()))
                    using (FileStream fileStream = File.Create(JsonLocation()));
                using (StreamReader streamReader = File.OpenText(JsonLocation()))
                {
                    JsonString = streamReader.ReadToEnd();
                }
                var list = JsonConvert.DeserializeObject<List<TicketModel>>(JsonString);
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        public void AddTicketToJson(TicketModel ticket)
        {
            try
            {
                var list = new List<TicketModel>();
                if (ConvertJsonToList() != null)
                    list = ConvertJsonToList();
                if (list.Count>0)
                    list.Add(new TicketModel(list[list.Count - 1].Id + 1, ticket.ProblemName, ticket.ColorARGB));
                else list.Add(new TicketModel(1, ticket.ProblemName, ticket.ColorARGB));

                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                using (StreamWriter outputFile = new StreamWriter(JsonLocation()))
                {
                    outputFile.Write(convertedJson);
                }
            }
            catch(Exception ex)
            {

            }
        }
        public string JsonLocation()
        {
            var a = Path.Combine(_ticketsJsonFolder, Constants.JsonName);
            return a;
        }

        public List<TicketModel> GetFiltredList(string searchTitle)
        {
            var list = new List<TicketModel>();
            if (ConvertJsonToList() != null)
            {
                list = ConvertJsonToList();
                list = list.FindAll(m => m.ProblemName.Contains(searchTitle));
            }
            return list;
        }
        
    }
}
