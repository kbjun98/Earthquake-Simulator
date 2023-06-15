using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BriefingUIHandler : MonoBehaviour
{
    public GameObject briefingUI;
    private GameObject situation, objective, map, hint;

    void Awake()
    {
        situation = GameObject.Find("Image_Situation");
        objective = GameObject.Find("Image_Objective");
        map = GameObject.Find("Image_Map");
        hint = GameObject.Find("Image_Hint");
    }
    void Start()
    {
        situation.SetActive(true);
        objective.SetActive(false);
        map.SetActive(false);
        hint.SetActive(false);
    }

    void Update()
    {
    }

    public void OnBackSelectClick()
    {
        //SceneManager.LoadScene(1);
    }

    public void OnBriefingQuitClick()
    {
        var sound = GameObject.Find("Sound_click").GetComponent<AudioSource>();
        sound.Play();
        SceneManager.LoadScene("GameSelect");
    }
    public void OnBriefingStageClick()
    {
        var sound = GameObject.Find("Sound_confirm").GetComponent<AudioSource>();
        sound.Play();
        SceneManager.LoadScene("GameSelect");
    }
    public void OnBriefingStartClick()
    {
        var sound = GameObject.Find("Sound_confirm").GetComponent<AudioSource>();
        sound.Play();
        SceneManager.LoadScene("Stage1");
        var sound_manager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        sound_manager.Stop_BGM();
    }
    public void OnSituationClick()
    {
        situation.SetActive(true);
        objective.SetActive(false);
        map.SetActive(false);
        hint.SetActive(false);
    }
    public void OnObjectiveClick()
    {
        situation.SetActive(false);
        objective.SetActive(true);
        map.SetActive(false);
        hint.SetActive(false);
    }
    public void OnMapClick()
    {
        situation.SetActive(false);
        objective.SetActive(false);
        map.SetActive(true);
        hint.SetActive(false);
    }
    public void OnHintClick()
    {
        situation.SetActive(false);
        objective.SetActive(false);
        map.SetActive(false);
        hint.SetActive(true);
    }
}
