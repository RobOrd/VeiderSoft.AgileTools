using CODE.Framework.Wpf.Mvvm;
using Project.Client.SHAGenerator.Models.User;

namespace Project.Client.SHAGenerator.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return ViewModal(new LoginViewModel(), ViewLevel.Popup);
        }
    }
}
