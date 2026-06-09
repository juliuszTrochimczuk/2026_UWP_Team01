using Abstraction;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;

    private Dictionary<string, Sound> soundsMap = new();

    protected override AudioManager CreateInstance() => this;

    protected override void Init()
    {
        AudioSource[] existingSources = GetComponents<AudioSource>();
        foreach (AudioSource source in existingSources)
        {
            Destroy(source);
        }

        soundsMap.Clear();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            if (soundsMap.ContainsKey(s.name))
                Debug.LogWarning($"Found duplicate sound '{s.name}'");
            soundsMap[s.name] = s;
        }
    }

    public void Play(string name)
    {
        if (soundsMap.TryGetValue(name, out Sound s))
        {
            s.source.Play();
        }
    }

    public void Stop(string name)
    {
        if (soundsMap.TryGetValue(name, out Sound s))
        {
            s.source.Stop();
        }
    }
}
