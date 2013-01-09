using Microsoft.Xna.Framework.Input.Touch;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felicitas {
    class Platformer : Game
    {
        #region Texture

        public static Texture2D BasicTileTexture;

        public static Texture2D PlayerTexture;

        #endregion

        public GraphicsDeviceManager graphicsDeviceManager;
        public static SpriteBatch spriteBatch;
        public static Level currentLevel;
        public static Player player;
        public static double windowHeight, windowWidth;

        public Platformer()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;

            windowHeight = App.RootFrame.RenderSize.Width;
            windowWidth = App.RootFrame.RenderSize.Height;

            TouchPanel.EnabledGestures = GestureType.Flick;

            graphicsDeviceManager.SupportedOrientations = DisplayOrientation.LandscapeRight;

            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }

        protected override void BeginRun()
        {
            base.BeginRun();
        }

        protected override void Initialize()
        {
            Window.Title = "Felicitas";
            //Load tile Textures here. Loading them in LoadContent was causing incorrect behavior, and the textures were not loading properly.
            #region TextureInitialize
            BasicTileTexture = Content.Load<Texture2D>("basicTile.dds");
            PlayerTexture = Content.Load<Texture2D>("player.dds");
            #endregion
            currentLevel = new FileGenerated();
            currentLevel.Generate("MAP.txt");
            player = new Player(10, 400, PlayerTexture);
            base.Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {
            float camY,camX;

            GraphicsDevice.Clear(Color.Red);

            camY = -player.Pos.Y + ((float)windowHeight/2.0f);
            camX = -player.Pos.X + ((float)windowWidth/2.0f);

            spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Matrix.Translation(camX, camY-(5*player.SpriteTexture.Height), 0) * Matrix.RotationZ(1.57079633f));
            currentLevel.Draw();
            player.Draw();
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            player.update();

            base.Update(gameTime);
        }
    }
}