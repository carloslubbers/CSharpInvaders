using System;

namespace SpaceInvaders
{
#if WINDOWS || XBOX
    static class Program
    {
        /// The main entry point.
        static void Main(string[] args)
        {
            using (Space game = new Space())
            {
                game.Run();
            }
        }
    }
#endif
}

