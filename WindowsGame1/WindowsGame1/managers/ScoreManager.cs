using System;
using SpaceInvaders.entities.components;
using SpaceInvaders.entities.ship;

namespace SpaceInvaders.managers
{
    public class ScoreManager
    {

        public int Score;
        private readonly BaseShip _player;

        public ScoreManager(BaseShip player)
        {
            _player = player;
        }

        public void AddScore(int points) {
            Score += points;

            PointScored();
        }

        private void PointScored()
        {
            var tc = _player.GetComponent<TextureComponent>();
            var fc = _player.GetComponent<FiringComponent>();

            Console.WriteLine("Points: " + Score);
            switch (Score)
            {
                case 10:
                    tc.SetTexture("blueshipTexture");
                    _player.MovementSpeed = 10.0f;
                    break;
                case 20:
                    fc.SetDelay(150);
                    break;
            }
        }
    }
}
