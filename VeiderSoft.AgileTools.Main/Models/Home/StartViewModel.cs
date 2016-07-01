using System.Windows;
using CODE.Framework.Wpf.Mvvm;

namespace Project.Client.SHAGenerator.Models.Home
{
    public class StartViewModel : ViewModel
    {
        public static StartViewModel Current { get; set; }

        public StartViewModel()
        {
            Current = this;
        }

        public void LoadActions()
        {
            Actions.Clear();

            // TODO: The following list of actions is used to populate the application's main navigation area (such as a menu or a home screen)

            Actions.Add(new ViewAction("Menu Item #1", execute: (a, o) => Controller.Message("Menu Item #1 clicked!")) { Significance = ViewActionSignificance.AboveNormal });
            Actions.Add(new ViewAction("Menu Item #2", execute: (a, o) => Controller.Message("Menu Item #2 clicked!")));
            Actions.Add(new ViewAction("Menu Item #3", execute: (a, o) => Controller.Message("Menu Item #3 clicked!")));

            Actions.Add(new ViewAction("SHA-1 Gen", category: "Tools", execute: (a, o) => Controller.Action("Home", "Shagen"), brushResourceKey: "CODE.Framework-Icon-Comment"));
            Actions.Add(new ViewAction("Password Gen", category: "Tools", execute: (a, o) => Controller.Action("Home", "Passgen"), brushResourceKey: "CODE.Framework-Icon-Login"));

            Controller.Action("Home", "Bing");
        }
    }
}
