using System.Collections; //contains things like bite arrays, objects, dictonarsya nd hash tables
using System.Collections.Generic; //generic just imports the objects. has better preformince.
using UnityEngine; // tells VS code what libaries we are using.
using UnityEngine.SceneManagement; // imports the unity sceen management API

public class Main : MonoBehaviour // the MonoBehavior class is what tells the editor what to do.
{
    public void PlayGame () //creates a new fucntion called playgame
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3); //gets sceen index  and changes to sceen 1 (from the menu) menu = sceen 0
    }

    public void QuitGame () // script for the exit button
    {
        Application.Quit(); // quits the game

        Debug.Log("game quit sucessfully"); //editor does not quit, this shows that the task was carried out sucessfully.
    }
}

// note: clone this script for paue button, and bringg you back to main menu. <if you go further add save game>