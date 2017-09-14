using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingStartGate : LapGate {

    public Vector3[] playerStartPositions;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for (int i = 0; i < playerStartPositions.Length; i++)
        {
            Gizmos.DrawSphere(transform.TransformPoint(playerStartPositions[i]), 0.8f);
        }
    }
}
