namespace ChatApp.Controllers
{
    using ChatApp.Models.Chat;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        private static readonly IList<KeyValuePair<string, string>> messages =
            new List<KeyValuePair<string, string>>();

        [HttpGet]
        public IActionResult Show()
        {
            if (messages.Count == 0)
            {
                return View(new ChatViewModel());
            }

            var chatViewModel = new ChatViewModel()
            {
                AllMessages = messages
                   .Select(m => new MessageViewModel()
                   {
                       Sender = m.Key,
                       Message = m.Value
                   })
                   .ToArray()
            };

            return View(chatViewModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chatViewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Show");
            }

            KeyValuePair<string, string> currentMessage = new KeyValuePair<string, string>(chatViewModel.CurrentMessage.Sender, chatViewModel.CurrentMessage.Message);

            messages.Add(currentMessage);

            return this.RedirectToAction("Show");
        }
    }
}
