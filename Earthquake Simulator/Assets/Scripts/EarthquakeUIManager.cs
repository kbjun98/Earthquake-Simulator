using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EarthquakeUIManager : MonoBehaviour
{

    public Image earthquakeCastingBar;
    public TextMeshProUGUI earthquakeName;
    public GameObject earthquakeManager;
    public float duration=5;
    
    void Start()
    {
        //StartCoroutine(Wait10Sec());
    }

    void Update()
    {
        earthquakeCastingBar.fillAmount += Time.deltaTime/duration;
    }

    public void setNextEarthquake(string name,float nextDuration)
    {
        earthquakeName.text= name;
        earthquakeCastingBar.fillAmount= 0;
        duration= nextDuration;
    }

    IEnumerator Wait10Sec()
    {
        //yield return new WaitForSeconds(11.0f);
        yield return null;
    }
}
