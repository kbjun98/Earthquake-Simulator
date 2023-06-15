using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    //for sound volume test
    public AudioSource audioSource;
    public Image fadeImage;
    public GameObject Floor1;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("옵션창 진입");
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)) // for sound test
        {
            audioSource.Play();
        }
    }

    IEnumerator FadeIn()
    {
        fadeImage.enabled = true;
        float fadeVal = 0;
        while (fadeVal < 1.0f)
        {
            fadeVal += 0.005f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0, 0, 0, fadeVal);
        }
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Result");
    }

    public void GameOver()
    {
        StartCoroutine(FadeIn());
    }
}
