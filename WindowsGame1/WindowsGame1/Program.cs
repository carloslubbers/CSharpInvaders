using SpaceInvaders.world;

namespace SpaceInvaders
{
#if WINDOWS || XBOX
    static class Program
    {
        /// The main entry point.
        static void Main()
        {
            using (var game = new Space())
            {
                game.Run();
            }
        }
    }
#endif
}

