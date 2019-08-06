using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : PhysicsObj
{
    Ball wreckingBall;
    Vector3 translationVector;
    private bool forward;

    public void Advance()
    {
        translationVector.x = GetEndVelocity();
        // Debug.Log(GetDistance());
        if (Input.GetKey(KeyCode.D))
        {
            SetTime(GetTime() + Time.deltaTime);
            GetWreckingBall().SetTime(GetTime());
            // GetWreckingBall().SetPhase(2);
            forward = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            SetTime(GetTime() + Time.deltaTime);
            GetWreckingBall().SetTime(GetTime());
            // GetWreckingBall().SetPhase(1);
            forward = false;
        }
        if (GetForward() == false)
        {
            translationVector.x *= -1;
        }
        if (GetForward() == false && translationVector.x < 0 || GetForward() == true && translationVector.x > 0)
        {
            transform.Translate(translationVector * Time.deltaTime);
            // GetWreckingBall().Translation(translationVector);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (GetTime() > 0)
            {
                SetTime(GetTime() - Time.deltaTime);
                //GetWreckingBall().SetTime(GetTime());
            }
            else if (GetTime() < 0)
            {
                SetTime(0);
                //GetWreckingBall().SetTime(GetTime());
                //GetWreckingBall().SetPhase(0);
            }
        }
    }

    public void Breaking()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetTime(0);
            //GetWreckingBall().SetTime(GetTime());
            //GetWreckingBall().SetPhase(0);
        }
    }

    public void SetWreckingBall(Ball wBall)
    {
        wreckingBall = wBall;
    }

    public Ball GetWreckingBall()
    {
        return wreckingBall;
    }

    public bool GetForward()
    {
        return forward;
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
        SetWreckingBall(GetComponentInChildren<Ball>());
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
