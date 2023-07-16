
namespace Homies.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    using Services.Contracts;
    using System.Security.Claims;

    using Homies.Models.Event;

    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private string UserId
        {
            get { return User.FindFirstValue(ClaimTypes.NameIdentifier); }
        }
        private string? UserEmail
        {
            get { return User.Identity.Name; }
        }

        public EventController(IEventService _eventService)
        {
            this.eventService = _eventService;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.GetAllEventsAsync();

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            return View(await eventService.GetAddViewAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await eventService.AddEventAsync(viewModel, this.UserId);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Join(int Id)
        {
            await eventService.AddEventToUsersCollectionAsync(Id, this.UserId);

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Joined()
        {
            var model = await eventService.GetUsersJoinedEventsAsync(this.UserId);

            return View(model);
        }

        public async Task<IActionResult> Leave(int id)
        {
            await eventService.LeaveEventForUserAsync(id, this.UserId);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await eventService.GetEditViewModelAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEventViewModel viewModel)
        {
            await eventService.EditEventAsync(viewModel);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await eventService.GetDetailsAboutEventAsync(id));
        }

    }
}
