using System.Windows;
using System.Windows.Media;

namespace VeiderSoft.AgileTools.Main.Models.Home.Classes
{
    public class IconWrapper
    {
        public string Name { get; set; }
        public ResourceDictionary Dictionary { get; set; }

        public Brush Icon
        {
            get { return (Brush)Dictionary[Name]; }
        }
    }
}
