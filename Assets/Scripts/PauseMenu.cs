using JetBrains.Annotations;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Referanse til PauseMenu gameobjektet v�rt. Dette er panelet vi vil skru av og p�
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;

    // En m�te � se om spillet er pauset eller ikke
    private bool isPaused = false;

    // P� hver frame har lyst til � se om spilleren har trykket p� escape
    private void Update()
    {
        // Hvis spilleren har trykket p� escape, s� vil vi gj�re noe
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            // Hvis spilleren v�r trykker p� escape og spillet IKKE er pauset, gj�r:
            if (!isPaused)
            {
                // Aktiver menyen v�r
                pauseMenu.SetActive(true);
                // Stoppe tiden
                Time.timeScale = 0;
                // Sett isPaused til true
                isPaused = true;
            } else
            {
                // Motsatt av alt ovenfor - Unpause
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }

    // Public metode for � starte spillet - Resume
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void OpenSettingsMenu()
    {
        // Deaktiver pause menu
        pauseMenu.SetActive(false);
        // Aktivere settings menu
        settingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    // Public metode for � avslutte spillet - Quit.
    public void QuitGame()
    {
        Debug.Log("Spillet avsluttes!");
        Application.Quit();
    }

}
