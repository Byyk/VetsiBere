using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetsiBere.Model.Components
{
    public partial class ConsoleControl : UserControl
    {
        public ConsoleControl()
        {
            InitializeComponent();
            this.Register();
            Console.commandEntered += (string s, string[] aegs) =>
            {
                if(Console.KnownCommands.Any(c => c.Equals(s)) || s == "") return;
                AddToLog("Neplatný příkaz!");
            };
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterCommand();
            }
        }

        public void EnterCommand()
        {
            var command = Regex.Split(textBox1.Text, " ");

            if (command.Length == 0) return;
            if (command.Length == 1) Console.commandEntered?.Invoke(command[0], new string[]{});
            else
            {
                var args = command.ToList();
                args.RemoveAt(0);
                Console.commandEntered?.Invoke(command[0], args.ToArray());
            }
            textBox1.Clear();
        }

        public void AddToLog(string t)
        {
            richTextBox1.AppendText(t + "\n");
            richTextBox1.ScrollToCaret();
        }
    }

    public static class Console
    {
        public static Action<string, string[]> commandEntered;

        public static void LogToConsole(string log)
        {
            console.AddToLog(log);
        }

        private static ConsoleControl console;

        public static void Register(this ConsoleControl c)
        {
            console = c;
        }

        public static List<string> KnownCommands = new List<string>{ "kill", "make-god", "give-card" };
    }
}
