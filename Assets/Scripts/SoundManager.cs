using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            /// Sound manager is not setup
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
        {
            /// Sound manager is already setup
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private AudioSource EffectSource;

    public void PlaySound(AudioClip clip)
    {
        EffectSource.PlayOneShot(clip);
    }

}
