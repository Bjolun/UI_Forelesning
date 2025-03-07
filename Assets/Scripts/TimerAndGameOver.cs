using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerAndGameOver : MonoBehaviour
{
    // Referanse til teksten vår som skal telle ned
    [SerializeField] private TextMeshProUGUI timerText;

    // Referanse til gameover panelet vårt slik at vi kan skru det av og på
    [SerializeField] private GameObject gameOverPanel;

    // Sette verdi på timer i sekunder
    [SerializeField] private int timer;

    // Vite hvilken scene som er aktiv slik at vi kan reloade scenen.
    private int currentActiveScene;

    private void Awake()
    {
        currentActiveScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Når vi starter spillet vil vi gjøre følgende...
    private void Start()
    {
        // Oppdatere teksten som står i telleren vår slik at vi har rett verdier
        timerText.text = "Time Remaining: " + timer;
        // Kalle på en metode som oppdaterer tiden hvert sekund slik at tiden går ned...
        InvokeRepeating("UpdateTimer", 1, 1);
    }

    // Lage en metode som teller ned og sjekker gjenstående tid.
    private void UpdateTimer()
    {
        // Hvis timeren er mer enn null (hvis det er tid igjen) så skal vi gjøre noe
        if(timer > 0)
        {
            // Teller ned ett sekund
            timer--;
            // Oppdatere teksten slik at den viser rett gjenværende tid.
            timerText.text = "Time Remaining: " + timer;
        }
        // Hvis tiden er ute, så skal vi gjøre noe annet
        else
        {
            // Aktivere game over panelet vårt
            gameOverPanel.SetActive(true);
            // Stoppe tiden
            Time.timeScale = 0f;
        }
    }

    // Lage metode for å restarte spillet når vi trykker på knappen vår.
    public void RestartGame()
    {
        // Starte tiden på nytt
        Time.timeScale = 1f;
        // Disable gameover meny
        gameOverPanel.SetActive(false);
        // Last scene på nytt (currently active)
        SceneManager.LoadScene(currentActiveScene);

    }




}
