using SpaceInvaders.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.managers
{
    public class ScoreManager
    {

        public int score = 0;
        private BaseShip player;

        public ScoreManager(BaseShip _player)
        {
            player = _player;
        }

        public void AddScore(int points) {
            score += points;

            pointScored();
        }

        private void pointScored() {
            TextureComponent tc = (TextureComponent)player.components["texture"];
            InputComponent ic = (InputComponent) player.components["input"];
            FiringComponent fc = (FiringComponent) player.components["firing"];

            Console.WriteLine("Points: " + score);
            switch (score)
            {
                case 5:
                    tc.setTexture("blueshipTexture");
                    ic.movementSpeed = 10.0f;
                    break;
                case 10:
                    fc.setDelay(200);
                    break;
            }
        }
    }
}
