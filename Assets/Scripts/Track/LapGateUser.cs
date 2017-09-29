using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LapGateUserData : System.IComparable
{
    public string name;
    public List<float> lapTimes;
    public RacerColor racerCol;

    public int CompareTo(object obj)
    {
        LapGateUserData other = (LapGateUserData)obj;
        float totalTime = 0;
        float otherTotalTime = 0;
        for(int i = 0; i < lapTimes.Count; i++)
        {
            totalTime += lapTimes[i];
        }

        for (int i = 0; i < other.lapTimes.Count; i++)
        {
            otherTotalTime += other.lapTimes[i];
        }

        return (int)Mathf.Sign(totalTime - otherTotalTime);
    }
}

public class LapGateUser : MonoBehaviour, System.IComparable {
    public int gateNum;
    public LapGate lastGate;
    public LapGateUserData data;
    public Vector3 trackDir, upDir, trackAngle, lastGatePos;
    float lapTime;
    public int lap
    {
        get
        {
            return _lap;
        }
        set
        {
            if (data.lapTimes.Count < value - 1)
            {
                data.lapTimes.Add(0);
                data.lapTimes[data.lapTimes.Count - 1] = lapTime;
            }
            lapTime = 0;
            _lap = value;
        }
    }
    private int _lap;

    private void Start()
    {
        data.lapTimes = new List<float>();
    }

    // Update is called once per frame
    void Update () {
        lapTime += Time.deltaTime;
	}

    public int CompareTo(object obj)
    {
        if (lastGate != null)
        {
            if (lap > ((LapGateUser)obj).lap || ((lap == ((LapGateUser)obj).lap) && (gateNum > ((LapGateUser)obj).gateNum)))
            {
                return -1;
            }
            else if (gateNum == ((LapGateUser)obj).gateNum && lap == ((LapGateUser)obj).lap)
            {
                if((transform.position - lastGate.transform.position).magnitude > (((LapGateUser)obj).transform.position - lastGate.transform.position).magnitude)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 0;
        }
    }
}
