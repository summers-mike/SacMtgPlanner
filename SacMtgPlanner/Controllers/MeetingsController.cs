using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacMtgPlanner.Models;

namespace SacMtgPlanner.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly SacMtgPlannerContext _context;

        public MeetingsController(SacMtgPlannerContext context)
        {
            _context = context;
        }

        // GET: Meetings
        /*
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meeting.ToListAsync());
        }
        */

        /*
        public async Task<IActionResult> Index(string searchString)
        {
            var meetings = from m in _context.Meeting
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                meetings = meetings.Where(s => s.Subject.Contains(searchString));
            }

            return View(await meetings.ToListAsync());
        }
        */

        public async Task<IActionResult> Index(string meetingConductor, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> conductorQuery = from m in _context.Meeting
                                            orderby m.Conductor
                                            select m.Conductor;

            var meetings = from m in _context.Meeting
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                meetings = meetings.Where(s => s.Subject.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(meetingConductor))
            {
                meetings = meetings.Where(x => x.Conductor == meetingConductor);
            }

            var meetingConductorVM = new MeetingConductorViewModel();
            meetingConductorVM.conductors = new SelectList(await conductorQuery.Distinct().ToListAsync());
            meetingConductorVM.meetings = await meetings.ToListAsync();

            return View(meetingConductorVM);
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .SingleOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Subject,MeetingDate,Conductor,Invocation,Benediction,YouthSpeaker,SpeakerOne,SpeakerTwo,OpeningHymnNumber,OpeningHymnName,SacHymnNumber,SacHymnName,ClosingHymnNumber,ClosingHymnName")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Subject,MeetingDate,Conductor,Invocation,Benediction,YouthSpeaker,SpeakerOne,SpeakerTwo,OpeningHymnNumber,OpeningHymnName,SacHymnNumber,SacHymnName,ClosingHymnNumber,ClosingHymnName")] Meeting meeting)
        {
            if (id != meeting.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .SingleOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.ID == id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.ID == id);
        }
    }
}
