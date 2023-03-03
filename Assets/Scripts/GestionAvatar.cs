using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionAvatar : MonoBehaviour
{
    float vitesseX; // Variable de type float qui enregistre la vitesse horizontale de l'avatar
    public float vitesseXMax; // Variable de type float qui enregistre la vitesse horizontale maximale de l'avatar

    private static bool avatarEstMort; // Variable statique booléenne qui enregistre si l'avatar est mort

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si l'avatar n'est pas mort...
        if (!avatarEstMort)
        {
            // Si le joueur appuie sur la touche D ou la flèche Droite...
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {

            }
        }
    }
}
