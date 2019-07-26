using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : PhysicsObj
{
    Vector3 translationVector;
    private bool forward;

    void Advance()
    {
        translationVector.x = GetEndVelocity();
        Debug.Log(GetEndVelocity());
        if (Input.GetKey(KeyCode.D))
        {
            SetTime(GetTime() + Time.deltaTime);
            forward = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            SetTime(GetTime() + Time.deltaTime);
            forward = false;
        }
        if (forward == false)
        {
            translationVector.x *= -1;
        }
        if (forward == false && translationVector.x < 0 || forward == true && translationVector.x > 0)
        {
            transform.Translate(translationVector * Time.deltaTime);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (GetTime() > 0)
            {
                SetTime(GetTime() - Time.deltaTime);
            }
        }
    }

    void Breaking()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetTime(0);
        }
    }

    void Start()
    {
        Initializing();
    }

    void Update()
    {
        Think();
    }

    public override void Initializing()
    {
        base.Initializing();
        translationVector = Vector3.zero;
        forward = false;
    }

    public override void Think()
    {
        base.Think();
        Advance();
        Breaking();
    }
}
