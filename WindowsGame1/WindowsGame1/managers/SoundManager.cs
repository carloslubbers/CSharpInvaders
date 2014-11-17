using SpaceInvaders.entities.@interface;
using SpaceInvaders.world;
using Microsoft.Xna.Framework.Audio;

namespace SpaceInvaders.managers
{
    public class SoundManager : ILoadable
    {
        public void LoadContent()
        {
            
        }

        public void PlayLooped(string p)
        {
            var bgEffect = Space.ContentManager.Load<SoundEffect>(p);
            var instance = bgEffect.CreateInstance();
            instance.IsLooped = true;
            bgEffect.Play(0.1f, 0.0f, 0.0f);
        }

        public void Play(string p)
        {
            var bgEffect = Space.ContentManager.Load<SoundEffect>(p);
            bgEffect.Play(0.1f, 0.0f, 0.0f);
        }

        public void Play(string p, float vol)
        {
            var bgEffect = Space.ContentManager.Load<SoundEffect>(p);
            bgEffect.Play(vol, 0.0f, 0.0f);
        }

    }
}
