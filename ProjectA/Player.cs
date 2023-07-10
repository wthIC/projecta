using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjectA
{
    public class Player
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int counter;

        public Player(Texture2D texture, int rows, int cols) {
            Texture = texture;
            Rows = rows;
            Cols = cols;
            currentFrame = 0;
            totalFrames = rows * cols;
            counter = 0;
        }

        public void Update()
        {
            counter++;
            currentFrame = (int) counter / 10;
            if (currentFrame >= totalFrames)
            {
                currentFrame = 0;
                counter = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Cols;
            int height = Texture.Height / Rows;
            int row = currentFrame / Cols;
            int col = currentFrame % Cols;

            Rectangle sourceRectangle = new Rectangle(width * col, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    } 
}
