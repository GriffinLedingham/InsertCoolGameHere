﻿using Microsoft.Xna.Framework.Input.Touch;
using SharpDX;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felicitas
{
    class Player
    {
        public Vector2 Pos, Velocity;
        public Texture2D SpriteTexture;
        float AccelerationY = -0.3f;
        bool Jumping = true;
        bool LeftDown, RightDown;

        public Player(int x, int y, Texture2D texture)
        {
            SpriteTexture = texture;
            Pos.Y = y;
            Jumping = true;
            Pos.X = x;

            //TODO: Add collision detection which bumps character up if spawned on a tile.
            for (int i = Platformer.currentLevel.Width - 1; i >= 0; i--)
            {
                for (int j = Platformer.currentLevel.Height - 1; j >= 0; j--)
                {
                    while (Platformer.currentLevel.Tiles[i, j].CheckCollision(this))
                    {
                        Pos.Y += 4;
                    }
                }
            }
        }

        public void update()
        {
            //TODO: Add item checks.
            
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (TouchLocation tl in touchCollection)
            {
                if ((tl.State == TouchLocationState.Pressed))
                {
                    if (tl.Position.Y < Platformer.windowWidth / 2.0f)
                    {
                        LeftDown = true;
                    }
                    else
                    {
                        RightDown = true;
                    }
                }
                else if (tl.State == TouchLocationState.Released)
                {
                    LeftDown = RightDown = false;
                }
            }

            if (LeftDown)
            {
                Velocity.X -= .2f;
            }
            if (RightDown)
            {
                Velocity.X += .2f;
            }

            if (TouchPanel.IsGestureAvailable)
            {
                GestureSample sample = TouchPanel.ReadGesture();
                if (sample.GestureType == GestureType.Flick)
                {
                    if (sample.Delta.X > 0 && !Jumping)
                    {
                        AccelerationY = 1.3f;
                        Jumping = true;
                    }
                }
            }

            bool noHit = true;
            for (int i = Platformer.currentLevel.Width - 1; i >= 0; i--)
            {
                for (int j = Platformer.currentLevel.Height - 1; j >= 0; j--)
                {
                    if (Platformer.currentLevel.Tiles[i, j].CheckCollision(this))
                    {
                        noHit = false;
                    }
                }
            }
            if (noHit)
            {
                Jumping = true;
            }

            Pos.X += Velocity.X;
            for (int i = Platformer.currentLevel.Width - 1; i >= 0; i--)
            {
                for (int j = Platformer.currentLevel.Height - 1; j >= 0; j--)
                {
                    if (Platformer.currentLevel.Tiles[i, j].CheckCollision(this))
                    {
                        Pos.X -= Velocity.X;
                        Velocity.X = 0;
                        break;
                    }
                }
            }

            float sign;
            if (Velocity.X > 0)
            {
                sign = 1;
            }
            else if (Velocity.X < 0)
            {
                sign = -1;
            }
            else
            {
                sign = 0;
            }

            Velocity.X -= .1f * sign;

            if (Velocity.X > -.1 && Velocity.X < .1)
            {
                Velocity.X = 0;
            }
            if (Velocity.Y > 4)
            {
                Velocity.Y = 4.0f;
            }

            if (Jumping)
            {
                Velocity.Y -= AccelerationY;
                AccelerationY -= 0.09f;
            }

            Pos.Y += Velocity.Y;
            for (int i = Platformer.currentLevel.Width - 1; i >= 0; i--)
            {
                for (int j = Platformer.currentLevel.Height - 1; j >= 0; j--)
                {
                    if (Platformer.currentLevel.Tiles[i, j].CheckCollision(this))
                    {
                        Pos.Y -= Velocity.Y;
                        if (Velocity.Y > 0)
                        {
                            while (!Platformer.currentLevel.Tiles[i, j].CheckCollision(this))
                            {
                                Pos.Y += Velocity.Y / Math.Abs(Velocity.Y);
                            }
                            Pos.Y -= Velocity.Y / Math.Abs(Velocity.Y);
                            Velocity.Y = 0;
                            AccelerationY = 0;
                            Jumping = false;
                        }
                        else
                        {
                            Velocity.Y = -Velocity.Y / 2;
                        }

                        break;
                        break;
                    }
                }
            }

        }

        public void Draw()
        {
            //Platformer.spriteBatch.Begin();
            Platformer.spriteBatch.Draw(SpriteTexture, Pos, Color.White);
            //Platformer.spriteBatch.End();
        }
    }
}
