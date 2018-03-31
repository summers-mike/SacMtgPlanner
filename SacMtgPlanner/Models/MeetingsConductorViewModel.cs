using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SacMtgPlanner.Models
{
    public class MeetingConductorViewModel
    {
        public List<Meeting> meetings;
        public SelectList conductors;
        public string meetingConductor { get; set; }
    }
}