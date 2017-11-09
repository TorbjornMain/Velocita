using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public Vector3 SteerInput
    {
        get
        {
            return _steerInput;
        }
    }

    public float AccelInput
    {
        get
        {
            return _accelInput;
        }
    }

    public bool DriftPressed
    {
        get
        {
            return _driftPressed;
        }
    }

    public bool DriftHeld
    {
        get
        {
            return _driftHeld;
        }
    }

    public bool DriftReleased
    {
        get
        {
            return _driftReleased;
        }
    }

    public bool HopPressed
    {
        get
        {
            return _hopPressed;
        }
    }

    public bool HopHeld
    {
        get
        {
            return _hopHeld;
        }
    }

    public bool HopReleased
    {
        get
        {
            return _hopReleased;
        }
    }

    public bool ResetPressed
    {
        get
        {
            return _resetPressed;
        }
    }

    public bool active = true;
    protected Vector3 _steerInput;
    protected float _accelInput;
    protected bool _driftPressed;
    protected bool _driftHeld;
    protected bool _driftReleased;
    protected bool _hopPressed;
    protected bool _hopHeld;
    protected bool _hopReleased;
    protected bool _resetPressed;

}
