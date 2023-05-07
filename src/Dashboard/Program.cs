using Dashboard.Boards;

namespace Dashboard;

// ReSharper disable once UnusedType.Global
// ReSharper disable once ArrangeTypeModifiers
class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    // ReSharper disable once ArrangeTypeMemberModifiers
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        
        var baseBoard = new BaseBoard();
        
        Application.Run(baseBoard);
    }
}