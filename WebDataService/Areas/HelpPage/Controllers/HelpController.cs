using System;
using System.Web.Http;
using System.Web.Mvc;
using WebDataService.Areas.HelpPage.ModelDescriptions;
using WebDataService.Areas.HelpPage.Models;

namespace WebDataService.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        //public HelpController()
        //    : this(GlobalConfiguration.Configuration)
        //{
        //}

        //public HelpController(HttpConfiguration config)
        //{
        //    Configuration = config;
        //}

        //public HttpConfiguration Configuration { get; private set; }
        /// <summary>
        /// GlobalConfiguration By default
        /// </summary>
        protected static HttpConfiguration Configuration
        {
            get { return Startup.HttpConfiguration; }
        }

        public ActionResult Index()
        {


            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            var apigroups = Configuration.Services.GetApiExplorer().ApiDescriptions;
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}