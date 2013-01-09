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

        #region TileTexture

        public static Texture2D BasicTileTexture;

        #endregion

        #region Effects
        Effect DrawTileEffect;
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

            DrawTileEffect = Content.Load<Effect>(@"HLSL\DrawTiles.fxo");

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
            #region TileTextureInitialize
            BasicTileTexture = Content.Load<Texture2D>("basicTile.dds");
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

            /*
            DrawTileEffect.Parameters["TileTexture"].SetResource(BasicTileTexture);
            DrawTileEffect.Parameters["TileCount"].SetValue(1.0f);
            DrawTileEffect.Parameters["TextureSize"].SetValue(new Vector2(BasicTileTexture.Width, BasicTileTexture.Height));
            DrawTileEffect.Parameters["ImageSize"].SetValue(new Vector2(GraphicsDevice.BackBuffer.Width, GraphicsDevice.BackBuffer.Height));
            DrawTileEffect.Parameters["TilePositions"].SetValue(new Vector2[]{new Vector2(50,50)});
            
            GraphicsDevice.DrawQuad(DrawTileEffect);
            */
            base.Draw(gameTime);
        }

    }
}
