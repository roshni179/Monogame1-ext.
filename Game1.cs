using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame1__ext_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Random generator;
        Texture2D dinoTexture;
       
        Texture2D backgroundTexture;
        Texture2D backgroundTexture2;
        Texture2D CurrentbackgroundTexture;
        Texture2D drink1Texture;
        Texture2D drink2Texture2;
        Texture2D CurrentdrinkTexture;
        
       
      
        Vector2 dinoLocation;

  
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
           
            generator = new Random();

            this.Window.Title = "Graphics.Demo";

            dinoLocation = new Vector2(generator.Next(0, 750), 100);

          

            base.Initialize();
            int randomBackground, drinktextures;
            randomBackground = generator.Next(2);
            if (randomBackground == 0)
                CurrentbackgroundTexture = backgroundTexture;
            else
                CurrentbackgroundTexture = backgroundTexture2;
            drinktextures = generator.Next(2);
            if (drinktextures == 0)
                CurrentdrinkTexture = drink1Texture;
            else 
                    CurrentdrinkTexture = drink2Texture2;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            backgroundTexture = Content.Load<Texture2D>("beach");
            backgroundTexture2 = Content.Load<Texture2D>("night");
            dinoTexture = Content.Load<Texture2D>("dino");
            
            drink1Texture = Content.Load<Texture2D>("drink1");
            drink2Texture2 = Content.Load<Texture2D>("drink2");
           
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();



            _spriteBatch.Draw(CurrentbackgroundTexture, new Vector2(0,0), Color.White);
            _spriteBatch.Draw(dinoTexture, dinoLocation, Color.Beige);
            _spriteBatch.Draw(CurrentdrinkTexture, new Vector2(150, 400), Color.White);
            //_spriteBatch.Draw(drink2Texture2, new Vector2(150, 400), Color.White);
 
            _spriteBatch.End();

            

            base.Draw(gameTime);
        }
    }
}
