﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AUTHOR: LotteMakesStuff
//URL: https://gist.github.com/LotteMakesStuff/d179d28f29bc9bb499dc5260e0146154

public class StaticCoroutineRunner : MonoBehaviour
{
    public static void RunCoroutine(IEnumerator coroutine)
    {
        var go = new GameObject("runner");
        DontDestroyOnLoad(go);

        var runner = go.AddComponent<StaticCoroutineRunner>();

        runner.StartCoroutine(runner.MonitorRunning(coroutine));
    }

    IEnumerator MonitorRunning(IEnumerator coroutine)
    {
        while (coroutine.MoveNext())
        {
            yield return coroutine.Current;
        }

        Destroy(gameObject);
    }
}
