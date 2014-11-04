using Microsoft.Xna.Framework;
using SpaceInvaders.entities.ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace SpaceInvaders.world
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class BulletManager
    {
        Ammo[] playerBullets;
        int playerBulletCount = 0;
        Timer timer;
        static Boolean ready = true;

        public BulletManager()
        {
            playerBullets = new Ammo[100];
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(TimerFinished);
            timer.Interval = 250;
            timer.Enabled = true;
        }

        public void createPlayerBullet(Ammo _ammo, Vector2 p) {            
            timer.Start();

            if (ready)
            {
                timer.Stop();

                playerBullets[playerBulletCount % playerBullets.Length] = _ammo;
                playerBullets[playerBulletCount % playerBullets.Length].Fire(p);
                playerBulletCount++;

                ready = false;
                timer.Start();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (playerBulletCount > 0)
            {
                for(int i = 0; i<playerBullets.Length;i++)
                {
                    if (playerBullets[i] != null)
                    {
                        playerBullets[i].Update(gameTime);
                    }
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (playerBulletCount > 0)
            {
                for (int i = 0; i < playerBullets.Length; i++)
                {
                    if (playerBullets[i] != null)
                    {
                        playerBullets[i].Draw(gameTime);
                    }
                }
            }
        }

        private static void TimerFinished(object source, ElapsedEventArgs e)
        {
            ready = true;
        }

        public Ammo[] getPlayerBullets()
        {
            return playerBullets;
        }
    }
}
