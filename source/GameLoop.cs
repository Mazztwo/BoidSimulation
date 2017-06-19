using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BirdClass;

namespace BOIDF
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class GameLoop
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Boid())
                game.Run();
        }
    }
}
