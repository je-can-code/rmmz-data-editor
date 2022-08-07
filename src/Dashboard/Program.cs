using Dashboard.Boards;

namespace Dashboard;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        var baseBoard = new BaseBoard();
        Application.Run(baseBoard);
    }
}