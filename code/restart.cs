using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    [SerializeField] private string level;
    public void Nextscene(string level)
    {
        SceneManager.LoadScene(level); // gets sceen name that we want then loads it, you can also use the sceen number
    }
}
