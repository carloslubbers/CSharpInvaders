using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.entities.enemy;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.interfaces;
using SpaceInvaders.world;
using IDrawable = SpaceInvaders.entities.interfaces.IDrawable;

namespace SpaceInvaders.managers
{
    public class EnemyManager : IDrawable, IUpdatable, ILoadable
    {
        private readonly Space _space;
        readonly BaseEnemy[] _enemies;
        const int MaxEnemyWidth = 15;

        public EnemyManager(Space space, int amount)
        {
            _space = space;
            _enemies = new BaseEnemy[amount];
            for (var i = 0; i < _enemies.Length; i++)
            {
                switch (i / MaxEnemyWidth)
                {
                    case 0:
                        _enemies[i] = new BaseEnemy(space);
                        var tc1 = (TextureComponent)_enemies[i].Components["texture"];
                        tc1.SetTexture("enemy1Texture");
                        break;
                    case 1:
                        _enemies[i] = new BaseEnemy(space);
                        var tc2 = (TextureComponent)_enemies[i].Components["texture"];
                        tc2.SetTexture("enemy2Texture");
                        break;
                    case 2:
                        _enemies[i] = new BaseEnemy(space);
                        var tc3 = (TextureComponent)_enemies[i].Components["texture"];
                        tc3.SetTexture("enemy3Texture");
                        break;
                    default:
                        _enemies[i] = new BaseEnemy(space);
                        var tc4 = (TextureComponent)_enemies[i].Components["texture"];
                        tc4.SetTexture("enemy1Texture");
                        break;
                }
            }

        }

        public void Initialize()
        {
            foreach (var e in _enemies)
            {
                e.Initialize();
            }
        }

        public void Update(GameTime gameTime)
        {
            var entityId = 0;
            foreach (var e in _enemies)
            {
                if (entityId == 0 || entityId == (MaxEnemyWidth-1))
                {
                    var bc = (BoundaryComponent)e.Components["boundary"];
                    var pc = (PositionComponent)e.Components["position"];
                    var tc = (TextureComponent)e.Components["texture"];
                    // Change X direction when screen edge has been reached
                    if (bc.GetSafeBounds().Left == pc.EntityPosition.X || bc.GetSafeBounds().Right - tc.Texture.Width == pc.EntityPosition.X)
                    {
                        foreach (var pc2 in _enemies.Select(e2 => (PositionComponent)e2.Components["position"]))
                        {
                            if (pc2.EntityPosition.Y < _space.Viewport.Height)
                            {
                                pc2.EntityPosition.Y +=100.0f;
                            }
                            pc2.EntitySpeed.X = pc2.EntitySpeed.X * -1;
                        }
                    }
                }

                entityId++;
            }

            foreach (var e in _enemies)
            {
                e.Update(gameTime);
            }
        }

        public void LoadContent()
        {
            var entityId = 0;
            foreach(var e in _enemies) {
                // Calculate offset for enemy
                var oc = (OffsetComponent)e.Components["offset"];
                oc.SetOffset(75.0f * (entityId % MaxEnemyWidth)+ 50.0f, 10.0f + (entityId / MaxEnemyWidth) * 50.0f);
                entityId++;
                e.LoadContent();
            }
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var e in _enemies)
            {
                e.Draw(gameTime);
            }
        }

        public void ResetEnemies()
        {
            foreach (var e in _enemies.Where(e => e != null))
            {
                e.Active = true;
            }
        }

        public BaseEnemy[] GetEnemies()
        {
            return _enemies;
        }

    }
}
