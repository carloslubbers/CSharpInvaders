using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class EnemyManager : Drawable, Updatable, Loadable
    {

        BaseEnemy[] enemies;
        const int maxEnemyWidth = 15;

        public EnemyManager(int amount)
        {
            enemies = new BaseEnemy[amount];
            for (int i = 0; i < enemies.Length; i++)
            {
                switch (i / maxEnemyWidth)
                {
                    case 0:
                        enemies[i] = new BaseEnemy();
                        TextureComponent tc1 = (TextureComponent)enemies[i].components["texture"];
                        tc1.setTexture("enemy1Texture");
                        break;
                    case 1:
                        enemies[i] = new BaseEnemy();
                        TextureComponent tc2 = (TextureComponent)enemies[i].components["texture"];
                        tc2.setTexture("enemy2Texture");
                        break;
                    case 2:
                        enemies[i] = new BaseEnemy();
                        TextureComponent tc3 = (TextureComponent)enemies[i].components["texture"];
                        tc3.setTexture("enemy3Texture");
                        break;
                    default:
                        enemies[i] = new BaseEnemy();
                        TextureComponent tc4 = (TextureComponent)enemies[i].components["texture"];
                        tc4.setTexture("enemy1Texture");
                        break;
                }
            }

        }

        public void Initialize()
        {
            foreach (BaseEnemy e in enemies)
            {
                e.Initialize();
            }
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            int entityID = 0;
            foreach (BaseEnemy e in enemies)
            {
                if (entityID == 0 || entityID == (maxEnemyWidth-1))
                {
                    BoundaryComponent bc = (BoundaryComponent)e.components["boundary"];
                    PositionComponent pc = (PositionComponent)e.components["position"];
                    TextureComponent tc = (TextureComponent)e.components["texture"];
                    // Change X direction when screen edge has been reached
                    if (bc.getSafeBounds().Left == pc.entityPosition.X || bc.getSafeBounds().Right - tc.texture.Width == pc.entityPosition.X)
                    {
                        foreach (BaseEnemy e2 in enemies)
                        {
                            PositionComponent pc2 = (PositionComponent)e2.components["position"];
                            pc2.entitySpeed.X = pc2.entitySpeed.X * -1;
                        }
                    }
                }

                entityID++;
            }

            foreach (BaseEnemy e in enemies)
            {
                KeyboardState ks = Keyboard.GetState(PlayerIndex.One);
                if (ks.IsKeyDown(Keys.R))
                {
                    foreach (BaseEnemy _e in enemies)
                    {
                        if (_e != null)
                        {
                            _e.active = true;
                        }
                    }
                }
                e.Update(gameTime);
            }
        }

        public void LoadContent()
        {
            int entityID = 0;
            foreach(BaseEnemy e in enemies) {
                // Calculate offset for enemy
                OffsetComponent oc = (OffsetComponent)e.components["offset"];
                oc.setOffset(75.0f * (float)(entityID % maxEnemyWidth), 10.0f + (entityID / maxEnemyWidth) * 50.0f);
                entityID++;
                e.LoadContent();
            }
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (BaseEnemy e in enemies)
            {
                e.Draw(gameTime);
            }
        }

        public BaseEnemy[] getEnemies()
        {
            return enemies;
        }
    }
}
