using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : PhysicsObj
{
    Ball wreckingBall;
    Vector3 translationVector;
    private bool forward;
    private bool limitCollide;

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
        if (GetForward() == false && translationVector.x < 0 && GetLimitCollide() == false 
            || GetForward() == true && translationVector.x > 0 && GetLimitCollide() == false)
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
        if (Input.GetKeyDown(KeyCode.S) || GetLimitCollide() == true)
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

    public void SetLimitCollide(bool coll)
    {
        limitCollide = coll;
    }

    public bool GetForward()
    {
        return forward;
    }

    public bool GetLimitCollide()
    {
        return limitCollide;
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Limit")
        {
            if (GetForward() == true)
            {
                SetLimitCollide(true);
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Limit")
        {
            if (GetForward() == true)
            {
                Debug.Log("asd");
                SetLimitCollide(true);
            }
            else
            {
                SetLimitCollide(false);
            }
        }
    }
}
