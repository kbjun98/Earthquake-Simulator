using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EarthQuakeType { Strong, Weak, Calm, Slide};

public struct EarthQuake
{
    public EarthQuakeType type;
    public float amount;
    public float duration;
    public float cameraShakeTime;
    public string name;
    public Vector3 gravity;

    public static EarthQuake strong(float amount,float duration, float cameraShakeTime)
    {
        EarthQuake eq;
        eq.type = EarthQuakeType.Strong;
        eq.amount = amount*4f;
        eq.duration = duration * 2f;
        eq.cameraShakeTime = eq.duration;   //cameraShakeTime; //*1.5f;
        eq.gravity = new Vector3(0, -9.8f, 0);
        eq.name = "Strong";
        return eq;
    }

    public static EarthQuake weak(float amount, float duration, float cameraShakeTime)
    {
        EarthQuake eq;
        eq.type = EarthQuakeType.Weak;
        eq.amount = amount;
        eq.duration = duration*3f;
        eq.cameraShakeTime = eq.duration;   //cameraShakeTime;
        eq.gravity = new Vector3(0, -9.8f, 0);
        eq.name = "Weak";
        return eq;
    }

    public static EarthQuake slide(float amount, float duration, float cameraShakeTime)
    {
        Vector2 gravity_xz = Random.insideUnitCircle;
        Vector3 gravity = new Vector3(9.8f*gravity_xz.x,-9.8f,9.8f*gravity_xz.y);

        EarthQuake eq;
        eq.type = EarthQuakeType.Slide;
        eq.amount = amount;
        eq.duration = duration;
        eq.cameraShakeTime = eq.duration;   //cameraShakeTime;
        eq.gravity = gravity;
        eq.name = "Slide";
        return eq;
    }

    public static EarthQuake calm(float amount, float duration, float cameraShakeTime)
    {
        EarthQuake eq;
        eq.type = EarthQuakeType.Calm;
        eq.amount = amount * 0.2f;
        eq.duration = duration*4f;
        eq.cameraShakeTime = eq.duration;   //cameraShakeTime;
        eq.gravity = new Vector3(0,0,0);
        eq.name = "Calm";
        return eq;
    }
}
