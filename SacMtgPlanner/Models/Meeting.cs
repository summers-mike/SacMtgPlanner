using System;
using System.ComponentModel.DataAnnotations;

namespace SacMtgPlanner.Models
{
    public class Meeting
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Subject { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }

        [Display(Name = "Conducting")]
        [Required]
        [StringLength(50)]
        public string Conductor { get; set; }

        [Required]
        [StringLength(50)]
        public string Invocation { get; set; }

        [Required]
        [StringLength(50)]
        public string Benediction { get; set; }

        [Display(Name = "Youth Speaker")]
        public string YouthSpeaker { get; set; }

        [Display(Name = "1st Speaker")]
        public string SpeakerOne { get; set; }

        [Display(Name = "2nd Speaker")]
        public string SpeakerTwo { get; set; }

        [Required]
        [Display(Name = "Opening Hymn")]
        public string OpeningHymnName { get; set; }

        [Display(Name = "Opening Hymn Number")]
        [Range(1, 341)]
        [DataType(DataType.Text)]
        public int OpeningHymnNumber { get; set; }

        [Required]
        [Display(Name = "Sacrament Hymn")]
        public string SacHymnName { get; set; }

        [Display(Name = "Sacrament Hymn Number")]
        [Range(1, 341)]
        [DataType(DataType.Text)]
        public int SacHymnNumber { get; set; }

        [Required]
        [Display(Name = "Closing Hymn")]
        public string ClosingHymnName { get; set; }

        [Display(Name = "Closing Hymn Number")]
        [Range(1, 341)]
        [DataType(DataType.Text)]
        public int ClosingHymnNumber { get; set; }
    }
}
