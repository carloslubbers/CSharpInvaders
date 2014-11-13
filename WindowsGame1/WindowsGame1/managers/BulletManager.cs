using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.Xna.Framework;
using SpaceInvaders.entities.ammo;

namespace SpaceInvaders.managers
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public class BulletManager
    {
        readonly Ammo[] _playerBullets;
        int _playerBulletCount;
        readonly Timer _timer;
        int _timerDelay = 250;
        static Boolean _ready = true;

        public BulletManager()
        {
            _playerBullets = new Ammo[100];
            _timer = new Timer();
            _timer.Elapsed += TimerFinished;
            _timer.Interval = _timerDelay;
            _timer.Enabled = true;
        }

        public void FirePlayerBullet(Ammo ammo, Vector2 p) {            
            _timer.Start();

            if (!_ready) return;
            _timer.Stop();

            _playerBullets[_playerBulletCount % _playerBullets.Length] = ammo;
            _playerBullets[_playerBulletCount % _playerBullets.Length].Fire(p);
            _playerBulletCount++;

            _ready = false;
            _timer.Start();
        }

        public void Update(GameTime gameTime)
        {
            if (_playerBulletCount <= 0) return;
            foreach (var t in _playerBullets.Where(t => t != null))
            {
                t.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (_playerBulletCount <= 0) return;
            foreach (var t in _playerBullets.Where(t => t != null))
            {
                t.Draw(gameTime);
            }
        }

        private static void TimerFinished(object source, ElapsedEventArgs e)
        {
            _ready = true;
        }

        public IEnumerable<Ammo> GetPlayerBullets()
        {
            return _playerBullets;
        }

        public void SetDelay(int d)
        {
            _timerDelay = d;
            _timer.Interval = d;
        }
    }
}
