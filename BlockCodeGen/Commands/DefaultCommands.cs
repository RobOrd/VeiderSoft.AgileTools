using System;

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

        public static string prop(string p1)
        {
            return $"{ConsoleFormatting.Indent(2)} prop with p1={p1}";
        }
        public static string prop(string p1, string p2)
        {
            return $"{ConsoleFormatting.Indent(2)} prop with p1={p1}, p2={p2}";
        }
        public static string prop(string p1, string p2, string p3)
        {
            return $"{ConsoleFormatting.Indent(2)} prop with p1={p1}, p2={p2}, p3={p3}";
        }
    }
}
