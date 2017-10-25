using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMine : PowerupEntity {
    public float width = 40;
    public PowerupEntity minePrefab;
    public float mineFloatHeight = 7;

	// Use this for initialization
	void Start () {
        RaycastHit rc = new RaycastHit();
        if(Physics.Raycast(transform.position, new Vector3(0, -1, 0), out rc, 1000, 1 << LayerMask.NameToLayer("Terrain")))
        {
            Vector3 minePos = rc.point + new Vector3(0, mineFloatHeight, 0);
            PowerupEntity po = null;
            Vector3 mineAxis = Vector3.Cross(rc.normal, transform.forward);
            for(int i = -1; i < 2; i+=2)
            {
                rc = new RaycastHit();
                if(!Physics.Raycast(minePos, mineAxis.normalized * i, out rc, width/2))
                { 
                    if (rc.distance == 0)
                    {
                        po = Instantiate(minePrefab);
                        po.transform.position = minePos + i * mineAxis * width / 2;
                        po.p = p;
                    }
                }
            }
            po = Instantiate(minePrefab);
            po.transform.position = minePos;
            po.p = p;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
