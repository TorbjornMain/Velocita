using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour {

    public Vector3 backFoot;
    public Vector3 frontFoot;
    public Transform board;
    public Vector3 backFootAngle, frontFootAngle;
    public CameraController cam;
    Animator anim;

    [System.NonSerialized]
    public Vector3 lookVector;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
        anim.SetIKPosition(AvatarIKGoal.RightFoot, board.TransformPoint(backFoot));
        anim.SetIKPosition(AvatarIKGoal.LeftFoot, board.TransformPoint(frontFoot));
        anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
        anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
        anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.Euler(backFootAngle) * transform.rotation);
        anim.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.Euler(frontFootAngle) * transform.rotation);
        anim.SetLookAtWeight(1);
        anim.SetLookAtPosition(cam.lookAt.transform.position);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(board.TransformPoint(backFoot), 0.1f);
        Gizmos.DrawSphere(board.TransformPoint(frontFoot), 0.1f);
    }

}
