using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Ha en referanse til lydkilden v�r (AudioSource)
    [SerializeField] private AudioSource audioSource;

    // Ha en referanse til slideren v�r
    [SerializeField] private Slider volumeSlider;

    // Se om vi spiller musikk eller ikke.
    private bool isPlayingMusic = true;

    // Lage en metode for � skru av og p� musikken - Toggle
    public void ToggleMusic()
    {
        // Endre status p� isPlayingMusic til motsatt av det den er n�
        isPlayingMusic = !isPlayingMusic;
        
        if(isPlayingMusic)
        {
            // Hvis isPlayingMusic er true, spill av musikk
            audioSource.Play();
        }
        
        else
        {
            // Hvis isPlayingMusic er false, stopp/pause musikken
            audioSource.Pause();
        }
    }

    // Lage en metode som styrer volum med slideren v�r
    public void SliderVolume()
    {
        // Audio source sin volum skal v�re like slideren sin verdi
        audioSource.volume = volumeSlider.value;
    }


}
