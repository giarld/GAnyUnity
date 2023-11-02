using System;
using Gx;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private void Awake()
    {
        if (!GAnyPlugin.Instance.Init())
        {
            Debug.LogError("GAnyPlugin initialization failed!!");
            return;
        }

        var intAny = GAny.Create(123);
        var floatAny = GAny.Create(3.1415f);
        var stringAny = GAny.Create("Hello");
        var funcAny = GAny.Function((v1, v2) => v1 + v2);
        
        Debug.Log($"Int: {intAny}");
        Debug.Log($"Float: {floatAny}");
        Debug.Log($"String: {stringAny}");
        Debug.Log($"Call func: {funcAny.Call(23, 32)}");
    }

    private void OnApplicationQuit()
    {
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        GAnyPlugin.Instance.UnInit();
    }
}