
using System;
using System.Collections.Generic;
using KonkeMunicipality.Models;

namespace KonkeMunicipality.Services
{
    public class MunicipalEventService
    {
        public List<MunicipalEvent> GetAllItems()
        {
            List<MunicipalEvent> items =
                new List<MunicipalEvent>();

            // Sample municipal event
            items.Add(new MunicipalEvent
            {
                EventId = "EVT-001",
                Title = "Community Clean-Up Campaign",
                Description = "Residents are invited to help clean public spaces and keep our municipality clean.",
                Location = "Konke Community Hall",
                EventDate = DateTime.Today.AddDays(7),
                Category = "Community",
                Type = "Event"
            });

            // Sample municipal event
            items.Add(new MunicipalEvent
            {
                EventId = "EVT-002",
                Title = "Community Meeting",
                Description = "A public meeting to discuss local service delivery priorities and community concerns.",
                Location = "Municipal Hall",
                EventDate = DateTime.Today.AddDays(14),
                Category = "Public Meeting",
                Type = "Event"
            });

            // Sample municipal announcement
            items.Add(new MunicipalEvent
            {
                EventId = "ANN-001",
                Title = "Water Conservation Notice",
                Description = "Residents are encouraged to use water responsibly and report leaks to the municipality.",
                Location = "All municipal areas",
                EventDate = DateTime.Today,
                Category = "Public Notice",
                Type = "Announcement"
            });

            // Sample municipal announcement
            items.Add(new MunicipalEvent
            {
                EventId = "ANN-002",
                Title = "Waste Collection Reminder",
                Description = "Please place household waste at the designated collection point on your scheduled collection day.",
                Location = "All municipal areas",
                EventDate = DateTime.Today,
                Category = "Service Notice",
                Type = "Announcement"
            });

            return items;
        }
    }
}

