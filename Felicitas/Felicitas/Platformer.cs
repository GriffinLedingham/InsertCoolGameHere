﻿using SharpDX;
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

        #region TileTexture

        public static Texture2D BasicTileTexture;

        public static Texture2D PlayerTexture;

        #endregion

        public GraphicsDeviceManager graphicsDeviceManager;
        public static SpriteBatch spriteBatch;
        public static Level currentLevel;

        public Platformer()
        {
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.SynchronizeWithVerticalRetrace = false;

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
            base.Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            //Draw whichever level is currently being played.
            //This will be changed when adding menus, multiple levels, etc..
            currentLevel.Draw();
            base.Draw(gameTime);
        }

    }
}
