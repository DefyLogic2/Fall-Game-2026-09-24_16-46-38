using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ticker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float CustomTickRate_1 = 0.2f;
    public float CustomTickRate_2 = 1f;
    public float Tick_Timer = 0f;
    void Start()
    {
        
    }
    public delegate void TickAction();
    public static event TickAction OnTickAction;
    // Update is called once per frame
    void Update()
    {
        Tick_Timer += Time.deltaTime;
        if (Tick_Timer >= CustomTickRate_1)
        {
            Tick_Timer = 0;
            TickEvent();
        }
    }
    public void TickEvent() 
    {
        OnTickAction?.Invoke();
    }

    /*
     * How to Implement*
     private void OnEnable()
    {
    Ticker.OnTickAction += Tick;
    }
    private void OnDisable()
    {
    Ticker.OnTickAction -=Tick;
    }

     private void Tick()
    {
       < Logic Goes Here 
    }
     
     */
}
