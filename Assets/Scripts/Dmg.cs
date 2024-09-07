using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Dmg : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    public Text livesText;

    public Image black;
    public Animator go;
    public Animator gg;
    public Animator hf;
    public Animator w;

    void Start()
    {
        currentLives = maxLives;
        UpdateLifeUI();
    }

    void Update()
    {

    }



    void UpdateLifeUI()
    {
        livesText.text = currentLives.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("badguy"))
        {
            if (currentLives > 0)
            {
                TakeDamage();
            }
        }

        if (other.CompareTag("PowerUp"))
        {
            
            if (currentLives < maxLives)
            {
                TakeHealth();
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("Portal"))
        {
            hf.SetBool("Win", true);
            w.SetBool("WinT", true);
        }

    }

    void TakeDamage()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            Debug.Log("Game Over");
            go.SetBool("Fade", true);
            gg.SetBool("Gameover", true);
        }

        UpdateLifeUI();
    }

    void TakeHealth()
    {

        if (currentLives + 1 <= maxLives)
        {
            currentLives += 1;
        }

        UpdateLifeUI();
    }

}
