using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;





namespace BirdClass
{
    class Bird
    {
        // Bird animation
        public Texture2D BirdTexture;

        // Bird sprite texture dimensions
        int textureHeight;
        int textureWidth;

        // Position of Bird w/ respect to top left corner of screen
        public Vector2 BirdPosition;

  

        public void Initialize(Texture2D birdPicture, Vector2 position)
        {
            BirdTexture = birdPicture;
            textureHeight = BirdTexture.Height;
            textureWidth = BirdTexture.Width;
            
            // When mouse is clicked, position of mouseClick is top left of sprite.
            // To center sprite on mouseClick, move the center of sprite to the mouseclick,
            // which is calcualted by subtracting half the height and half the width
            // from the x and y coordinates of the mouse.
            BirdPosition = new Vector2(position.X - textureWidth/2, position.Y - textureHeight/2);
        }

        public void Update()
        {
            // Movement vector to push birdies 10 units in x-axis and 0 units in y-axis
            BirdPosition = Vector2.Add(BirdPosition, new Vector2(5,0));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(BirdTexture, BirdPosition, Color.White);

        }
       

    }
}
