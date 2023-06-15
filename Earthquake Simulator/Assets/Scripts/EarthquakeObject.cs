//using Codice.CM.WorkspaceServer.Tree.GameUI.Checkin.Updater;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeObject : MonoBehaviour
{
    public float mass;
    public bool freezeRotX;
    public bool freezeRotY;
    public bool freezeRotZ;
    public bool freezeMoveX;
    public bool freezeMoveY;
    public bool freezeMoveZ;
    private Rigidbody rb;

    private void Awake()
    {
        gameObject.isStatic = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(rb==null) rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = mass;
        rb.useGravity= true;
        RigidbodyConstraints rbc = rb.constraints;
        if (freezeRotX) rbc = rbc | RigidbodyConstraints.FreezeRotationX; 
        if (freezeRotY) rbc = rbc | RigidbodyConstraints.FreezeRotationY; 
        if (freezeRotZ) rbc = rbc | RigidbodyConstraints.FreezeRotationZ;
        if (freezeMoveX) rbc = rbc | RigidbodyConstraints.FreezePositionX;
        if (freezeMoveY) rbc = rbc | RigidbodyConstraints.FreezePositionY;
        if (freezeMoveZ) rbc = rbc | RigidbodyConstraints.FreezePositionZ;
        rb.constraints = rbc;

        Collider collider= GetComponent<Collider>();
        if (collider == null)
        {
            if (GetComponent<MeshRenderer>())
            {
                MeshCollider mc = gameObject.AddComponent<MeshCollider>();
                mc.convex = true;
            }
            else
            {
                BoxCollider bc = gameObject.AddComponent<BoxCollider>();
            }
        }
        gameObject.tag = "EarthQuakeObject";
        EarthquakeManager.eqObjectList.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void earthQuake(float amount)
    {
        rb.AddForce(Random.insideUnitSphere * amount);
    }
}
