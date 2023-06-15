using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool hardMode = false;
    public Material darkSkyBox;
    public Light mainLight;
    public Camera playerCamera;
    public GameObject flashLightSpawner;
    public Inventory inventory;
    public Item flashLight;
    public const float darkFog = 0.55f;

    void Awake()
    {
        // Real hardmode checker
        hardMode = GameObject.Find("SoundManager").GetComponent<SoundManager>().hardMode;
    }

    void Start()
    {
        Cursor.visible = false;
        //hardMode= true;               //temp
        if(hardMode)
        {
            flashLightSpawner.SetActive(false);
            RenderSettings.skybox = darkSkyBox;
            inventory.addItem(flashLight);
            mainLight.intensity = 0;
            RenderSettings.fog = true;
            RenderSettings.fogDensity = darkFog;
            RenderSettings.fogColor = Color.black;
            playerCamera.backgroundColor= Color.black;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
        }
    }
}
