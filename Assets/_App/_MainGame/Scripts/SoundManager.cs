using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;
    
    public static SoundManager Instance = null;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }
    
    public void PlaySingle(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
    
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
    
    public void RandomizeSfx(params AudioClip[] clips)
    {
        var randomIndex = Random.Range(0, clips.Length);
        var randomPitch = Random.Range(lowPitchRange, highPitchRange);
        
        sfxSource.pitch = randomPitch;
        sfxSource.clip = clips[randomIndex];
        sfxSource.Play();
    }
}
