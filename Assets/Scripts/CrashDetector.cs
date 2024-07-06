using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool crashed = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && crashed == false)
        {
            crashed = true;
            FindObjectOfType<PlayerScript>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadDelay);

        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
