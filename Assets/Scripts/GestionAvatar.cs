using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionAvatar : MonoBehaviour
{
    [Header("Vitesses")]
    float vitesseX; // Variable de type float qui enregistre la vitesse HORIZONTALE de l'avatar
    public float vitesseXMax; // Variable de type float qui enregistre la vitesse HORIZONTALE MAXIMALE de l'avatar
    float vitesseY; // Variable de type float qui enregistre la vitesse VERTICALE de l'avatar
    public float vitesseSaut; // Variable qui enregistre la vitesse de SAUT de l'avatar

    public static bool avatarEstMort; // Variable statique bool�enne qui enregistre si l'avatar est mort
    public static bool partieEnCours; // Variable statique bool�enne qui enregistre si la partie est en cours //////////////////// Peut �tre changer de script

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si le jeu est en cours...
        if (partieEnCours)
        {
            // Si l'avatar n'est pas mort...
            if (!avatarEstMort)
            {
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////// D�PLACEMENTS ET MOUVEMENTS
                /**************************************************************************************************************** D�placements horizontaux */
                // Si le joueur appuie sur la touche D ou la fl�che Droite...
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    vitesseX = vitesseXMax; // L'avatar se d�place vers la droite
                    GetComponent<SpriteRenderer>().flipX = false; // L'avatar regarde vers la droite
                }
                // Si le joueur appuie sur la touche A ou la fl�che Gauche...
                else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    vitesseX = -vitesseXMax; // L'avatar se d�place vers la gauche
                    GetComponent<SpriteRenderer>().flipX = true; // L'avatar regarde vers la gauche
                }
                // M�morise la vitesse actuelle en X
                else
                {
                    vitesseX = GetComponent<Rigidbody2D>().velocity.x;
                }

                // Applique les vitesses en X et en Y
                GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

                /**************************************************************************************************************** Animations de d�placement et de repos */
                // Si la vitesse de l'avatar est sup�rieur ou inf�rieur � 0...
                if (vitesseX > 0.01f || vitesseX < -0.01f)
                {
                    GetComponent<Animator>().SetBool("Course", true); // L'animation de course joue
                }
                // Sinon...
                else
                {
                    GetComponent<Animator>().SetBool("Course", false); // L'animation de repos joue
                }
            }
        }
        
    }
}
