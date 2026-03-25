using UnityEngine;

namespace Controllers
{
    public class AudioManager : PersistentSingleton<AudioManager>
    {
        protected override void CreateInstance() => Instance = this;

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
