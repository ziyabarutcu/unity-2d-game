using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource backgroundSource;
    public AudioSource sfxSource;
    public AudioSource blupSource;
    public AudioSource successSource;
    public AudioClip sfxClip;
    public AudioClip blupClip;
    public AudioClip successClip;
    public Collider colSc;
    public Reflection refSc;


    bool yandinPlayed = false;
    bool blupPlayed = false;
    bool successPlayed = false;
    bool mute = false;

    bool isPaused = false;

    void Start()
    {
        backgroundSource.loop = true;
        backgroundSource.Play();

        //Ses Volume'lerini başta ayarlama:
        backgroundSource.volume = 0.12f;
        sfxSource.volume = 0.2f;

    }
    void Update()
    {
        if (!colSc.canPlay && !yandinPlayed)
        {
            yandinPlayed = true;
            Yandin();
        }
        if (refSc.nowCollide && !blupPlayed)
        {
            blupPlayed = true;
            Sektin();
        }
        if (!refSc.nowCollide)
        {
            blupPlayed = false;
        }
        if (colSc.canSuccess && !successPlayed)
        {
            successPlayed = true;
            Success();
        }
    }
    public void Yandin()
    {
        sfxSource.PlayOneShot(sfxClip);
        backgroundSource.Stop();
    }
    public void Sektin()
    {
        blupSource.PlayOneShot(blupClip);
    }
    public void Success()
    {
        successSource.PlayOneShot(successClip);
        backgroundSource.Stop();
    }

    public void MuteAll()
    {
        if (!mute)
        {
            AudioListener.volume = 0f;
            mute = true;
        }
        else
        {
            AudioListener.volume = 1f;
            mute = false;
        }
    }


    public void PauseGame()//eğer oyunu duraklat butonuna basılırsa bu fonksiyon çalışır
    {
        if (!isPaused) //eğer oyun durmuş değilse
        {
            Time.timeScale = 0f; //oyunu durdur
            isPaused = true; // 
            backgroundSource.Pause(); //sesi de durdur
        }
        else //eğer oyun durmuşsa
        {
            Time.timeScale = 1f; //oyunu devam ettir
            isPaused = false;
            backgroundSource.UnPause(); //sesi de devam ettir
        }
    }
        
}
