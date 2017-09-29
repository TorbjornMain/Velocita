using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapGate : MonoBehaviour, System.IComparable
{
    public bool startGate = false;
    public int gateNum = 1;
    public int prevGateNum = 0;

    private void OnTriggerEnter(Collider other)
    {
        LapGateUser lg = other.GetComponent<LapGateUser>();
        if(lg != null)
        {
            if(lg.gateNum == prevGateNum || (startGate && lg.gateNum == 0))
            {
                if(startGate)
                {
                    lg.lap++;
                }
                lg.trackDir = transform.forward;
                lg.trackAngle = transform.eulerAngles;
                lg.upDir = transform.up;
                lg.lastGatePos = transform.position;
                lg.gateNum = gateNum;
                lg.lastGate = this;
            }
        }
    }

    public int CompareTo(object obj)
    {
        return (int)Mathf.Sign(((LapGate)obj).gateNum - gateNum);
    }
}
