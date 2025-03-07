using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerAndGameOver : MonoBehaviour
{
    // Referanse til teksten v�r som skal telle ned
    [SerializeField] private TextMeshProUGUI timerText;

    // Referanse til gameover panelet v�rt slik at vi kan skru det av og p�
    [SerializeField] private GameObject gameOverPanel;

    // Sette verdi p� timer i sekunder
    [SerializeField] private int timer;

    // Vite hvilken scene som er aktiv slik at vi kan reloade scenen.
    private int currentActiveScene;

    private void Awake()
    {
        currentActiveScene = SceneManager.GetActiveScene().buildIndex;
    }

    // N�r vi starter spillet vil vi gj�re f�lgende...
    private void Start()
    {
        // Oppdatere teksten som st�r i telleren v�r slik at vi har rett verdier
        timerText.text = "Time Remaining: " + timer;
        // Kalle p� en metode som oppdaterer tiden hvert sekund slik at tiden g�r ned...
        InvokeRepeating("UpdateTimer", 1, 1);
    }

    // Lage en metode som teller ned og sjekker gjenst�ende tid.
    private void UpdateTimer()
    {
        // Hvis timeren er mer enn null (hvis det er tid igjen) s� skal vi gj�re noe
        if(timer > 0)
        {
            // Teller ned ett sekund
            timer--;
            // Oppdatere teksten slik at den viser rett gjenv�rende tid.
            timerText.text = "Time Remaining: " + timer;
        }
        // Hvis tiden er ute, s� skal vi gj�re noe annet
        else
        {
            // Aktivere game over panelet v�rt
            gameOverPanel.SetActive(true);
            // Stoppe tiden
            Time.timeScale = 0f;
        }
    }

    // Lage metode for � restarte spillet n�r vi trykker p� knappen v�r.
    public void RestartGame()
    {
        // Starte tiden p� nytt
        Time.timeScale = 1f;
        // Disable gameover meny
        gameOverPanel.SetActive(false);
        // Last scene p� nytt (currently active)
        SceneManager.LoadScene(currentActiveScene);

    }




}
