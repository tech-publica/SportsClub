using Microsoft.AspNetCore.Mvc.Rendering;
using SportsClubModel.Domain;
using SportsClubWeb.ViewModels.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsClubWeb.ViewModels
{
    public class ReservationCreateViewModel
    {
        [DisplayName("Reserved By")]
        public long MemberId { get; set; }
        [DisplayName("Court")]
        public long CourtId { get; set; }
        [FutureDate]
        [DisplayName("Starts At")]
        public DateTime Start { get; set; }
        [FutureDate(ErrorMessage = "You cannot reserve in the past!")]
        [DisplayName("End at")]
        public DateTime End { get; set; }
        [Range(2,4)]
        public int NumPlayers { get; set; }
        public List<SelectListItem> Members { get; set; }
        public List<SelectListItem> Courts { get; set; }

        public ReservationCreateViewModel() { }

        public ReservationCreateViewModel(IEnumerable<Member> clubMembers, IEnumerable<Court> courts)
        {
            FillSelectLists(clubMembers, courts);
        }

        public void FillSelectLists(IEnumerable<Member> clubMembers, IEnumerable<Court> courts)
        {
            Start = DateTime.Today.AddHours(12);
            End = DateTime.Today.AddHours(13);
            Members = new List<SelectListItem>();
            foreach (var m in clubMembers)
            {
                Members.Add(new SelectListItem(m.FirstName + " " + m.LastName, m.Id.ToString()));
            }
            Courts = new List<SelectListItem>();
            foreach (var c in courts)
            {
                Courts.Add(new SelectListItem(c.Name, c.Id.ToString()));
            }
        }
    }
}
