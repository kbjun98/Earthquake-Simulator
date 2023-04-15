using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1UIHandler : MonoBehaviour
{
    public GameObject briefingUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBackSelectClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnBriefingQuitClick()
    {
        briefingUI.SetActive(false);
    }
}
