using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;

namespace CustomRPC
{
    static class Program
    {
        public static DiscordRpcClient Client { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CustomRPC());
        }

        public static void UpdateRPC(string appId, decimal days, decimal hours, decimal minutes, decimal seconds)
        {
            if (Client != null)
                Client.Dispose();

            Client = new DiscordRpcClient(appId);

            Client.Initialize();

            var activity = new RichPresence()
            {
                Timestamps = new Timestamps(DateTime.UtcNow - new TimeSpan((int)days, (int)hours, (int)minutes, (int)seconds)),
            };

            Client.SetPresence(activity);
        }
    }
}
