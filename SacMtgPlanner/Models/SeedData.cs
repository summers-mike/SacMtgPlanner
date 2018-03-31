using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SacMtgPlanner.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacMtgPlannerContext(
                serviceProvider.GetRequiredService<DbContextOptions<SacMtgPlannerContext>>()))
            {
                // Look for any meetings.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                context.Meeting.AddRange(
                    new Meeting
                    {
                        Subject = "Blessings of Tithing",
                        MeetingDate = DateTime.Parse("2018-4-8"),
                        Conductor = "Bishop Jones",
                        Invocation = "Bro. Petersen",
                        Benediction = "Sis. Petersen",
                        YouthSpeaker = "Abbey Jenkins",
                        SpeakerOne = "Sis. Holmes",
                        SpeakerTwo = "Bro. Holmes",
                        OpeningHymnNumber = 134,
                        OpeningHymnName = "I Believe in Christ",
                        SacHymnNumber = 178,
                        SacHymnName = "O Lord of Hosts",
                        ClosingHymnNumber = 124,
                        ClosingHymnName = "Be Still, My Soul",
                    },

                    new Meeting
                    {
                        Subject = "Hold to the Rod",
                        MeetingDate = DateTime.Parse("2018-4-15"),
                        Conductor = "Bro. Williams",
                        Invocation = "Bro. Reynolds",
                        Benediction = "Sis. Fields",
                        YouthSpeaker = "Conner Anderson",
                        SpeakerOne = "Sis. Larsen",
                        SpeakerTwo = "Bro. Larsen",
                        OpeningHymnNumber = 254,
                        OpeningHymnName = "True to the Faith",
                        SacHymnNumber = 171,
                        SacHymnName = "With Humble Heart",
                        ClosingHymnNumber = 274,
                        ClosingHymnName = "The Iron Rod",
                    },

                    new Meeting
                    {
                        Subject = "Faith",
                        MeetingDate = DateTime.Parse("2018-4-22"),
                        Conductor = "Bro. Byron",
                        Invocation = "Sis. Ricks",
                        Benediction = "Bro. Ricks",
                        YouthSpeaker = "Paige Hill",
                        SpeakerOne = "Sis. Cummings",
                        SpeakerTwo = "Sis. Thompson",
                        OpeningHymnNumber = 229,
                        OpeningHymnName = "Today, While the Sun Shines",
                        SacHymnNumber = 170,
                        SacHymnName = "God, Our Father, Hear Us Pray",
                        ClosingHymnNumber = 129,
                        ClosingHymnName = "Where Can I Turn for Peace?",
                    },

                    new Meeting
                    {
                        Subject = "Charity",
                        MeetingDate = DateTime.Parse("2018-4-29"),
                        Conductor = "Bishop Jones",
                        Invocation = "Bro. Robinson",
                        Benediction = "Sis. Robinson",
                        YouthSpeaker = "Carl Daniels",
                        SpeakerOne = "Sis. Andersen",
                        SpeakerTwo = "Bro. Hanks",
                        OpeningHymnNumber = 237,
                        OpeningHymnName = "Do What Is Right",
                        SacHymnNumber = 175,
                        SacHymnName = "O God, the Eternal Father",
                        ClosingHymnNumber = 241,
                        ClosingHymnName = "Count Your Blessings",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}