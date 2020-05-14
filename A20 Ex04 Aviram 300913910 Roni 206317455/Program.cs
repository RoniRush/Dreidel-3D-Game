namespace A20Ex04Aviram300913910Roni206317455
{
     using System;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new SpinTheDreidel())
                game.Run();
        }
    }
#endif
}
