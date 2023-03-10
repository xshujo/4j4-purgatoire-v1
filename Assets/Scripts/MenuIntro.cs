using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fonction qui ferme l'application
    public void quitterLApplication()
    {
        Application.Quit();
    }

    // Fonction qui charge la scène de jeu
    public void commencerJeu()
    {
        SceneManager.LoadScene("");
    }
}
