using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioMixerGroup musicMixerGroup;
    public static AudioManager Instance;

    public AudioClip titleScreen;
    public AudioClip background;
    public AudioClip death;
    public AudioClip checkpoint;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.clip = titleScreen;
            musicSource.loop = true;
            musicSource.playOnAwake = false;

            musicSource.outputAudioMixerGroup = musicMixerGroup;
            musicSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
             musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private bool isMuted = false;

    public void ToggleMute()
    {
        isMuted = !isMuted;

        if(isMuted)
        {
            musicMixerGroup.audioMixer.SetFloat("MusicVolume", -80f);
            musicMixerGroup.audioMixer.SetFloat("SFXVolume", -80f);
        }
        else
        {
            musicMixerGroup.audioMixer.SetFloat("MusicVolume", -5f);
            musicMixerGroup.audioMixer.SetFloat("SFXVolume", -5f);
        }
    }
}
