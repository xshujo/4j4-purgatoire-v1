using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionAvatar : MonoBehaviour
{
    [Header("Vitesses")]
    float vitesseX; // Variable de type float qui enregistre la vitesse HORIZONTALE de l'avatar
    public float vitesseXMax; // Variable de type float qui enregistre la vitesse HORIZONTALE MAXIMALE de l'avatar
    float vitesseY; // Variable de type float qui enregistre la vitesse VERTICALE de l'avatar
    public float vitesseSaut; // Variable qui enregistre la vitesse de SAUT de l'avatar

    public static Vector2 SpawnPoint; // Variable statique de type vector2 qui enregistre le dernier checkpoint pass� par l'avatar

    [Header("Gestion du jeu")]
    public static bool AvatarEstMort; // Variable statique bool�enne qui enregistre si l'avatar est mort
    public static bool PartieEnCours; // Variable statique bool�enne qui enregistre si la partie est en cours //////////////////// Peut �tre changer de script

    // Start is called before the first frame update
    void Start()
    {
        
    }
    /* Fin Start */

    // Update is called once per frame
    void Update()
    {
        // Si le jeu est en cours...
        if (PartieEnCours)
        {
            // Si l'avatar n'est pas mort...
            if (!AvatarEstMort)
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

                /**************************************************************************************************************** Saut et animation de saut */
                // Si le joueur appuie sur la touche W ou la fl�che Haut et que l'avatar touche au sol...
                if ((Input.GetKeyDown(KeyCode.W) && Physics2D.OverlapCircle(transform.position, 0.5f))
                    || (Input.GetKeyDown(KeyCode.UpArrow) && Physics2D.OverlapCircle(transform.position, 0.5f)))
                {
                    vitesseY = vitesseSaut; // L'avatar saute
                    GetComponent<Animator>().SetBool("Saut", true); // L'animation de saut joue
                }
                // M�morise la vitesse actuelle en Y
                else
                {
                    vitesseY = GetComponent<Rigidbody2D>().velocity.y; /////////////////////////////////////// Animation de saut � false?
                }
                // Applique les vitesses en X et en Y
                GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
            }
            // Si l'avatar meurt...
            else
            {
                GetComponent<Animator>().SetBool("Mort", true); // L'animation de mort joue
                Invoke("recommencerPartie", 5f); // On recommence la partie apr�s 5 secondes //////////////////////////////////////// Ajuster d�lai
            }
            /* Fin if (!AvatarEstMort) */
        }
        /* Fin if (PartieEnCours) */
    }
    /* Fin Update */

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// GESTION DES ENTR�ES DANS LES ZONES TRIGGER

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si l'avatar touche un objet dangereux... ///////////////////////////////// OnCollisionEnter2D ?
        if (collision.gameObject.tag == "Danger")
        {
            // Il meurt
            AvatarEstMort = true;
        }
        // Si l'avatar atteint un checkpoint...
        else if (collision.gameObject.tag == "Checkpoint")
        {
            SpawnPoint = collision.transform.position; ////////////////////////////////////////////// � tester
        }
    }
    /* Fin OnTriggerEnter2D() */

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// GESTION DES SC�NES

    // Fonction qui rejoue la partie quand l'avatar meurt
    void recommencerPartie()
    {
        SceneManager.LoadScene("SceneJeu"); // La partie est relanc�e
        transform.position = SpawnPoint; // L'avatar reappara�t au dernier checkpoint sauvegard�
    }
    /* Fin recommencerPartie() */
}
/* Fin class Mono behaviour */
