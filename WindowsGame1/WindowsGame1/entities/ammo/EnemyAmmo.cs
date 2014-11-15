namespace SpaceInvaders.entities.ammo
{
    class EnemyAmmo : Ammo
    {
        public EnemyAmmo()
        {
            TextureComponent.SetTexture("enemy1Texture");
            PositionComponent.EntitySpeed.Y = 15.0f;
        }
    }
}
