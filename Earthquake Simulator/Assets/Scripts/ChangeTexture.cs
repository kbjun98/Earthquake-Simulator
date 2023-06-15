using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    //public Texture towelTex;
    public Material towelMat;


    void Start()
    {
        //Renderer _renderer = gameObject.GetComponent<Renderer>();
        //_material = gameObject.GetComponent<Renderer>().material;
    }

    public void changeTexture()
    {
        gameObject.GetComponent<MeshRenderer>().material = towelMat;
        //_material.SetTexture("_MainTex", towelTex);
        //towelMat.SetTexture("_MainTex", towelTex);
    }
}
