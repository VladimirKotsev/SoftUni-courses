using Homies.Models.Event;

namespace Homies.Services.Contracts
{
    public interface IEventService
    {
        public Task<ICollection<EventViewModel>> GetAllEventsAsync();

        public Task<AddEventViewModel> GetAddViewAsync();

        public Task AddEventAsync(AddEventViewModel viewModel, string userId);

        public Task AddEventToUsersCollectionAsync(int id, string userId);

        public Task<ICollection<EventViewModel>> GetUsersJoinedEventsAsync(string userId);

        public Task LeaveEventForUserAsync(int eventId, string userId);

        public Task<EditEventViewModel> GetEditViewModelAsync(int eventId);

        public Task EditEventAsync(EditEventViewModel viewModel);

        public Task<EventDetailsViewModel> GetDetailsAboutEventAsync(int id);
    }
}
