namespace Homies.Services
{
    using Microsoft.EntityFrameworkCore;

    using System.Threading.Tasks;

    using Contracts;
    using Data;
    using Data.Models;
    using Models.Event;
    using System.Net;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext homiesDb)
        {
            this.dbContext = homiesDb;
        }

        public async Task<ICollection<EventViewModel>> GetAllEventsAsync()
        {
            var events = await dbContext
                .Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn,
                    Start = e.Start,
                    End = e.End,
                    Organiser = e.Organiser.Email,
                    Type = e.Type.Name,
                })
                .ToListAsync();

            return events;
        }

        public async Task<AddEventViewModel> GetAddViewAsync()
        {
            var types = await dbContext
                .Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();

            var model = new AddEventViewModel()
            {
                Types = types
            };

            return model;
        }

        public async Task AddEventAsync(AddEventViewModel viewModel, string userId)
        {
            if (!dbContext.Events.Any(e => e.OrganiserId == userId && e.Name == viewModel.Name))
            {
                Event myEvent = new Event()
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd H:mm")),
                    End = viewModel.End,
                    Start = viewModel.Start,
                    OrganiserId = userId,
                    TypeId = viewModel.TypeId,
                };

                await dbContext.Events.AddAsync(myEvent);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task AddEventToUsersCollectionAsync(int eventId, string userId)
        {
            var eventIsAlreadyAdded = await dbContext
                .EventParticipants
                .AnyAsync(ep => ep.HelperId == userId && ep.EventId == eventId);

            if (!eventIsAlreadyAdded)
            {
                var eventParticipant = new EventParticipant()
                {
                    HelperId = userId,
                    EventId = eventId,
                };

                await dbContext.EventParticipants.AddAsync(eventParticipant);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<EventViewModel>> GetUsersJoinedEventsAsync(string userId)
        {
            return await dbContext
                .EventParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(e => new EventViewModel()
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    Description = e.Event.Description,
                    Organiser = e.Event.Organiser.Email,
                    CreatedOn = e.Event.CreatedOn,
                    Start = e.Event.Start,
                    End = e.Event.End,
                    Type = e.Event.Type.Name
                })
                .ToListAsync();
        }

        public async Task LeaveEventForUserAsync(int eventId, string userId)
        {
            var eventParticipant = await dbContext
                .EventParticipants
                .FirstAsync(ep => ep.HelperId == userId && ep.EventId == eventId);

            dbContext
                .EventParticipants
                .Remove(eventParticipant);
            await dbContext.SaveChangesAsync();
        }

        public async Task<EditEventViewModel> GetEditViewModelAsync(int eventId)
        {
            var model = await dbContext
                .Events
                .Where(e => e.Id == eventId)
                .Select(e => new EditEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.TypeId
                })
                .ToListAsync();

            var types = await dbContext
                .Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();

            model[0].Types = types;

            return model[0];
        }

        public async Task EditEventAsync(EditEventViewModel viewModel)
        {
            var model = await dbContext
                .Events
                .FirstAsync(x => x.Id == viewModel.Id);

            model.Name = viewModel.Name;
            model.Description = viewModel.Description;
            model.Start = viewModel.Start;
            model.End = viewModel.End;
            model.TypeId = viewModel.TypeId;

            await dbContext.SaveChangesAsync();
        }

        public async Task<EventDetailsViewModel> GetDetailsAboutEventAsync(int id)
        {
            var model = await dbContext
                .Events
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    Organiser = e.Organiser.Email,
                    CreatedOn = e.CreatedOn,
                    Type = e.Type.Name
                })
                .ToListAsync();

            return model[0];
        }
    }
}
