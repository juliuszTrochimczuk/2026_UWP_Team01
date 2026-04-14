using Abstraction;
using UnityEngine;

namespace Managers
{
    public class AudioManager : PersistentSingleton<AudioManager>
    {
        protected override AudioManager CreateInstance() => this;

        [SerializeField] private AudioSource ambientSource;
        [SerializeField] private AudioSource sfxSource;

        public void PlayAmbient(AudioClip clip)
        {
            // TODO: implement ambient audio
        }

        public void StopAmbient()
        {
            // TODO: implement ambient audio stop
        }

        public void PlaySfx(AudioClip clip)
        {
            // TODO: implement sfx audio
        }
    }
}
