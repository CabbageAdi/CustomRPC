using DiscordRPC;

namespace CustomRPCCL;

public class Program
{
    public static DiscordRpcClient? Client { get; private set; }
    
    public static void Main(string[] args)
    {
        if (args.Length < 1)
            throw new ArgumentException("Not enough parameters provided.");

        if (args[0] == "set")
        {
            if (args.Length < 2)
                throw new ArgumentException("Not enough parameters provided.");
            
            if (!ulong.TryParse(args[1], out _))
                throw new ArgumentException("Cannot parse application id.");
            File.WriteAllText("appid.txt", args[1]);
            Console.WriteLine($"Set default application id to {args[1]}");
            return;
        }

        if (!File.Exists("appid.txt"))
            throw new InvalidOperationException("No application id set. Set it with the set command.");

        var appId = File.ReadAllText("appid.txt");
        if (!decimal.TryParse(args[0], out var days))
            throw new ArgumentException("Cannot parse day count.");

        if (args.Length > 1)
        {
            if (!decimal.TryParse(args[1], out var hours))
                throw new ArgumentException("Cannot parse hour count.");
            
            if (args.Length > 2)
            {
                if (!decimal.TryParse(args[2], out var minutes))
                    throw new ArgumentException("Cannot parse minute count.");

                if (args.Length > 3)
                {
                    if (!decimal.TryParse(args[3], out var seconds))
                        throw new ArgumentException("Cannot parse second count.");
                    
                    UpdateRPC(appId, days, hours, minutes, seconds);
                }
                else
                    UpdateRPC(appId, days, hours, minutes);
            }
            else
                UpdateRPC(appId, days, hours);
        }
        else
            UpdateRPC(appId, days);

        Console.WriteLine("Started. Press any key to terminate.");

        Console.Read();
        Console.WriteLine("Terminated.");
    }
    
    public static void UpdateRPC(string appId, decimal days, decimal hours = 0, decimal minutes = 0, decimal seconds = 0)
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