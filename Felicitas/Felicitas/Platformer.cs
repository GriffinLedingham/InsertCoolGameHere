using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felicitas {
    class Platformer : Game {

        public GraphicsDeviceManager graphicsDeviceManager;
        public SpriteBatch spriteBatch;



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
            base.Initialize();
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

    }
}
