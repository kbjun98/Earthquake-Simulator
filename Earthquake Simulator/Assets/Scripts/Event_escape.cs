using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Event_escape : MonoBehaviour
{
    public GameObject EventCheck;
    public Image fadeImage;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {   
            EventCheck.GetComponent<EventCheck>().escaped_stairs = true;
            Debug.Log("계단으로 탈출.");
            StartCoroutine(FadeIn());
        }
        

    IEnumerator FadeIn()
    {
        fadeImage.enabled= true;
        float fadeVal = 0;
        while(fadeVal < 1.0f)
        {
            fadeVal += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = new Color(0,0,0,fadeVal);
        }
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Result");
    }
    }
}