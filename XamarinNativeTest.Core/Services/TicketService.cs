using Acr.UserDialogs;
using MvvmCross.Platform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinNativeTest.Core.Services
{
    class TicketService : ITicketService
    {
        private readonly ITicketJsonLoccationServices _jsonLocationServices;
        private readonly string _jsonLocation;
        private List<TicketModel> AllTickets;
        public TicketService(ITicketJsonLoccationServices service)
        {
            _jsonLocationServices = service;
            _jsonLocation = JsonLocation();
            AllTickets = ConvertJsonToList();

        }
        public List<TicketModel> GetAllTickets()
        {
            return AllTickets.ToList();
        }

        public List<TicketModel> ConvertJsonToList()
        {
            try
            {
                var list = new List<TicketModel>();
                if (!File.Exists(_jsonLocation)) using (File.Create(_jsonLocation));
                using (StreamReader streamReader = File.OpenText(_jsonLocation))
                {
                    list = JsonConvert.DeserializeObject<List<TicketModel>>(streamReader.ReadToEnd()) ?? new List<TicketModel>();
                }
                return list;
            }
            catch(Exception ex)
            {
                Mvx.Resolve<IUserDialogs>().Alert("Something went wrong");
                return new List<TicketModel>();
            }
        }
        public void AddTicketToJson(TicketModel ticket)
        {
            try
            {
                AllTickets.Add(new TicketModel(AllTickets?.Count() + 1 ?? 1, ticket.ProblemName, ticket.TicketPriority));
                Save();
            }
            catch(Exception ex)
            {
                Mvx.Resolve<IUserDialogs>().Alert("Something went wrong");
            }
        }

        private void Save()
        {
            var convertedJson = JsonConvert.SerializeObject(AllTickets, Formatting.Indented);
            using (StreamWriter outputFile = new StreamWriter(_jsonLocation))
            {
                outputFile.Write(convertedJson);
            }
        }
        public string JsonLocation()
        {
            return Path.Combine(_jsonLocationServices.GetJsonFolder(), Constants.JsonName); ;
        }

        public List<TicketModel> GetFiltredList(string searchTitle)
        {
            return AllTickets.FindAll(m => m.ProblemName.Contains(searchTitle));
        }
        
    }
}
