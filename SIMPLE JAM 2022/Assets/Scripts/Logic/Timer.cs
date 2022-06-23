using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public delegate void onTimeOut();
    public static onTimeOut timeOut;
    public Slider slider;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        slider.DOValue(0,time).OnComplete(()=>timeOut?.Invoke());
    }   
}
