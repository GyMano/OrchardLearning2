using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;

namespace OL2.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer T;
        private readonly INotifier _notifier;
        private readonly IHtmlLocalizer H;
        private readonly ILogger _logger;

        public HomeController(IStringLocalizer<HomeController> stringLocalizer, INotifier notifier, IHtmlLocalizer<HomeController> htmlLocalizer, ILogger<HomeController> logger)
        {
            _notifier = notifier;
            _logger = logger;
            H = htmlLocalizer;
            T = stringLocalizer;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = T["Hello world from controller!"];
            _notifier.SuccessAsync(H["Localized HTML"]);
            _logger.LogWarning("WarningMessage");
            return View();
        }
    }
}
