﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BirdClass;
using System.Collections.Generic;

namespace BOIDF
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Boid : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MouseState oldMouseState;

        // The birdie object and its flock
        Bird birdie;
        List<Bird> flock = new List<Bird>();

        // The barrier object and the list of barriers
        // Barrier wall;
        //List<Barrier> walls = new List<Barrier>();


        public Boid()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Make mouse visible during game
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here



        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            // Get mouse states
    
            MouseState currMouseState = Mouse.GetState();

            //If let mouse is clicked, draw a birdie!
            if (currMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                // Initialize bird & add to flock
                birdie = new Bird();

                Vector2 birdPosition = new Vector2(currMouseState.X, currMouseState.Y);
                birdie.Initialize(Content.Load<Texture2D>("Images//birdie"), birdPosition);
              
                // Add birdie to flock after initialization
                flock.Add(birdie);
            }

            // Update mouseClick status
            oldMouseState = currMouseState;

            //Update the position of the flock 
            for (int i = 0; i < flock.Count; i++)
            {
                flock[i].Update();
            }



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            // Start drawing
            spriteBatch.Begin();

            // Draw flock
            for (int i = 0; i < flock.Count; i++)
            {
                flock[i].Draw(spriteBatch);
            }

            // Stop drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
