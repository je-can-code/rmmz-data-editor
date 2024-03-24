using JMZ.Dashboard.Boards;

namespace JMZ.Dashboard;

// ReSharper disable once UnusedType.Global
// ReSharper disable once ArrangeTypeModifiers
class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        
        var baseBoard = new BaseBoard();
        
        Application.Run(baseBoard);
    }
}