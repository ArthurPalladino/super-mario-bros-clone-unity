using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource oneShotAudioSource;
    public AudioSource backgroundSoundsAudioSource;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            oneShotAudioSource = gameObject.AddComponent<AudioSource>();
            oneShotAudioSource.spatialBlend = 0f;
            backgroundSoundsAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundSoundsAudioSource.spatialBlend = 0f;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void PlayOneShot(AudioClip clip)
    {
        oneShotAudioSource.PlayOneShot(clip);
    }



}
