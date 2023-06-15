using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeManager : MonoBehaviour
{
    public float amount;
    public float duration;
    public float cameraShakeTime;
    public float cameraShakeAmount;
    private int[] EQtype = {2,3,3,2,3,2,3,2,1,2};
    private int index = 0;

    public bool StartEarthquake = false;
    public bool Severe = false;

    private int nextEarthQuakeType;
    private EarthQuake currentEarthQuake;
    private EarthQuake nextEarthQuake;

    public GameObject playerCamera; 
    public GameObject player;

    public GameObject Sound_calm, Sound_weak, Sound_strong;

    public static List<EarthquakeObject> eqObjectList = new (); 

    public EarthquakeUIManager euim;

    private Quaternion originRotation;

    void Start()
    {
        originRotation = playerCamera.transform.localRotation;
        StartCoroutine(Waitfor10Sec());
        //StartCoroutine(earthQuake());
    }

    private IEnumerator earthQuake()
    {
        currentEarthQuake = nextEarthQuake;
        setNextEarthQuake();        // 먼저 지진타입 정하고
        //earthQuakeGravity();        //  
        earthQuakeCamera();
        earthQuakeObject();
        if (currentEarthQuake.name == "Calm")
        {
            Sound_calm.GetComponent<AudioSource>().enabled = true;
            Sound_weak.GetComponent<AudioSource>().enabled = false;
            Sound_strong.GetComponent<AudioSource>().enabled = false;
        }
        else if (currentEarthQuake.name == "Weak")
        {
            Sound_calm.GetComponent<AudioSource>().enabled = false;
            Sound_weak.GetComponent<AudioSource>().enabled = true;
            Sound_strong.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            Sound_calm.GetComponent<AudioSource>().enabled = false;
            Sound_weak.GetComponent<AudioSource>().enabled = false;
            Sound_strong.GetComponent<AudioSource>().enabled = true;
        }
        yield return new WaitForSeconds(currentEarthQuake.duration);
        StartCoroutine(earthQuake());
    }

    private void setNextEarthQuake()
    {
        //nextEarthQuakeType = Random.Range(0, 10);

        //for demo


        if (EQtype[index] == 2/*nextEarthQuakeType <= 4*/)
        {
            nextEarthQuake = EarthQuake.weak(amount, duration, cameraShakeTime);
            Severe = false;
        }
        else if (EQtype[index] == 3/*nextEarthQuakeType >= 8*/)
        {
            nextEarthQuake = EarthQuake.strong(amount, duration, cameraShakeTime);
            Severe = true;

        }
        else
        {
            //nextEarthQuake = EarthQuake.slide(amount, duration, cameraShakeTime);
            nextEarthQuake = EarthQuake.calm(amount, duration, cameraShakeTime);

            Severe = false;
        }
        index++;
        euim.setNextEarthquake(currentEarthQuake.name, currentEarthQuake.duration);
    }

    private void earthQuakeObject()
    {
        if(currentEarthQuake.type==EarthQuakeType.Strong||currentEarthQuake.type==EarthQuakeType.Weak)
        {
            foreach(EarthquakeObject obj in eqObjectList)
            {
                obj.earthQuake(currentEarthQuake.amount);
            }
        }
    }

    private void earthQuakeCamera()
    {
        if (currentEarthQuake.type == EarthQuakeType.Strong
            || currentEarthQuake.type == EarthQuakeType.Weak || currentEarthQuake.type == EarthQuakeType.Calm)
        {
            StartCoroutine(cameraShake());
        }
    }
    IEnumerator cameraShake()
    {
        float timer = 0;
        //Quaternion originRotation = playerCamera.transform.localRotation;
        Debug.Log(currentEarthQuake.cameraShakeTime);
        while (timer <= currentEarthQuake.cameraShakeTime)
        {
            playerCamera.transform.Rotate(
                Random.insideUnitSphere *
                currentEarthQuake.amount * cameraShakeAmount);
            timer += Time.deltaTime;
            yield return null;
        }
        playerCamera.transform.localRotation= originRotation;
        //playerCamera.transform.rotation = Quaternion.LookRotation(playerCamera.transform.forward, -Physics.gravity);

    }

    private void earthQuakeGravity()
    {
        StartCoroutine(changeGravity());
    }

    IEnumerator changeGravity()
    {
        float timer = 0;
        while (timer <= currentEarthQuake.cameraShakeTime)
        {

            Physics.gravity = Vector3.Slerp(
                Physics.gravity, 
                currentEarthQuake.gravity, 
                timer / nextEarthQuake.duration);
            

            //playerCamera.transform.rotation = Quaternion.LookRotation(playerCamera.transform.forward,-Physics.gravity);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Waitfor10Sec()
    {
        yield return new WaitForSeconds(11f);
        nextEarthQuake = EarthQuake.strong(amount,duration,cameraShakeTime);
        //euim.setNextEarthquake(nextEarthQuake.name, nextEarthQuake.duration);
        //yield return new WaitForSeconds(10f);
        StartCoroutine(earthQuake());
        //yield return null;
    }
}
