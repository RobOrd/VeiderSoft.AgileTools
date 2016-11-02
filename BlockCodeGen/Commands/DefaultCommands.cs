using System;
using System.Text;

// All console commands must be in the sub-namespace Commands:
namespace BlockCodeGen.Commands
{
    // Methods used as console commands must be public and must return a string
    public static class DefaultCommands
    {
        public static string cls()
        {
            Console.Clear();
            return string.Empty;
        }

        public static string help()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Block Code Generator");
            sb.AppendLine("Commands Help");

            sb.AppendLine(ConsoleFormatting.Indent(2) + "prop   <datatype> <propertyName> [options]");
            sb.AppendLine(ConsoleFormatting.Indent(6) + "-options for <for>");

            return sb.ToString();
        }

        public static string prop(string dataType, string propName)
        {
            var template = @"
            private $dt $propName;
            public $dt $PropName
            {
                get
                {
                    return $propName;
                }
                set
                {
                    if (value == $propName) return;
                    $propName = value;
                    NotifyChanged(\""$PropName\"");
                }
            }";

            return template.Replace("$dt", dataType).Replace("$propName", propName).Replace("$PropName", propName);
        }
    }
}
