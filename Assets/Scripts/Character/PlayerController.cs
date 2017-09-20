using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public enum RacerColor
{ Red = 0, Blue = 1, Green = 2, Yellow = 3, White = 4 }

public class PlayerController : Controller {

    public Camera cam;
    public Camera hudCam;
    public InputDevice id;
    public RacerColor colour;
    public bool finished = false;

    // Update is called once per frame
    void Update() {
        if (active)
        {
            if (id != null)
            {
                _accelInput = id.Action1;
                _driftHeld = id.RightBumper.IsPressed;
                _driftPressed = id.RightBumper.WasPressed;
                _driftReleased = id.RightBumper.WasReleased;
                _hopHeld = id.LeftBumper.IsPressed;
                _hopPressed = id.LeftBumper.WasPressed;
                _hopReleased = id.LeftBumper.WasReleased;
                _steerInput = new Vector3(id.LeftStick.Y, 0, id.LeftStick.X);
            }
            else
            {
                _accelInput = Input.GetButton("Jump") ? 1 : 0;
                _driftHeld = Input.GetButton("Fire1");
                _driftPressed = Input.GetButtonDown("Fire1");
                _driftReleased = Input.GetButtonUp("Fire1");
                _hopHeld = Input.GetButton("Fire2");
                _hopPressed = Input.GetButtonDown("Fire2");
                _hopReleased = Input.GetButtonUp("Fire2");
                _steerInput = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
            }
        }
	}

    public void Deactivate()
    {
        active = false;
        _accelInput = 0;
        _driftHeld = false;
        _driftPressed = false;
        _driftReleased = true;
        _hopHeld = false;
        _hopPressed = false;
        _hopReleased = true;
        _steerInput = Vector3.zero;
        StartCoroutine(FinishDeactivate());
    }

    IEnumerator FinishDeactivate()
    {
        yield return null;
        _driftReleased = _hopReleased = false;
    }

    void FinishRace()
    {
        Deactivate();
        finished = true;
    }
}
