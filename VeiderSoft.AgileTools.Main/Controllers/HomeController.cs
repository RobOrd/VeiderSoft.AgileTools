using CODE.Framework.Wpf.Mvvm;
using Project.Client.SHAGenerator.Models.Home;
using VeiderSoft.AgileTools.Main.Models.Home;

namespace Project.Client.SHAGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Start()
        {
            return Shell(new StartViewModel(), "Agile Development Tools");
        }

        public ActionResult Shagen()
        {
            return ViewModal("ShaGenerator",new ShaGeneratorViewModel());
        }

        public ActionResult Passgen()
        {
            return ViewModal("PasswordGenerator", new PasswordGeneratorViewModel());
        }

        public ActionResult Bing()
        {
            return ViewModal("Bing", new BingViewModel());
        }
    }
}
