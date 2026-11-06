using System.Reflection;

var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "0.0.0";

if (args.Length == 0 || args[0] is "-h" or "--help")
{
    Console.WriteLine($"efdrift {version}");
    Console.WriteLine("Detects drift between an EF Core model and a live SQL Server database.");
    Console.WriteLine();
    Console.WriteLine("Usage: efdrift check --project <path> --connection <connection-string>");
    return 0;
}

Console.Error.WriteLine("efdrift: the check command is not implemented yet. See ROADMAP in README.md.");
return 2;
