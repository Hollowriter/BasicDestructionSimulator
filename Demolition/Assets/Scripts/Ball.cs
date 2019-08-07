﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : PhysicsObj
{
    Vehicle parentVehicle;
    // Vector3 translationVector;
    Vector3 rotationVector;
    [SerializeField]
    float whileMovingLimit;
    [SerializeField]
    float maximumRotation;
    int phase;

    public void RotationWhileMove()
    {
        //Debug.Log("Rotation = " + GetRotationAngle());
        // Debug.Log("Distance = " + GetDistance());
        if (GetDistance() > 0 /*&& GetDistance() < maximumDistance*/ ||
            GetDistance() < 0 /*&& GetDistance() > maximumDistance * -1*/)
        {
            switch (phase)
            {
                case 0:
                    break;
                case 1:
                    rotationVector.z = GetEndVelocity();
                    break;
                case 2:
                    rotationVector.z = GetEndVelocity() * -1;
                    break;
            }
            if (parentVehicle.GetDistance() > 0 && 
                GetRotationAngle() > (maximumRotation - whileMovingLimit) * -1 ||
                parentVehicle.GetDistance() < 0 && 
                GetRotationAngle() < (maximumRotation - whileMovingLimit))
            {
                transform.Rotate(rotationVector);
            }
        }
    }

    public void PendularMovement()
    {
        switch (phase)
        {
            case 3:
                rotationVector.z = GetEndVelocity() * -1;
                break;
            case 4:
                rotationVector.z = GetEndVelocity();
                break;
        }
        if (parentVehicle.GetDistance() == 0 )
        {
            transform.Rotate(rotationVector);
            SetTime(GetTime() + Time.deltaTime);
        }
    }

    public void PhaseController()
    {
        if (parentVehicle.GetDistance() < 0)
        {
            SetPhase(1);
        }
        if (parentVehicle.GetDistance() > 0)
        {
            SetPhase(2);
        }

        if (parentVehicle.GetDistance() == 0)
        {
            switch (phase)
            {
                case 1:
                    SetPhase(3);
                    break;
                case 2:
                    SetPhase(4);
                    break;
            }
        }

        if (GetPhase() == 3 && GetRotationAngle() < maximumRotation * -1 ||
            GetPhase() == 4 && GetRotationAngle() > maximumRotation)
        {
            switch (phase)
            {
                case 3:
                    SetPhase(4);
                    break;
                case 4:
                    SetPhase(3);
                    break;
            }
        }
    }

    /*public void Translation(Vector3 consecuence)
    {
        transform.Translate(consecuence * Time.deltaTime);
        Debug.Log("chupamela, la concha de tu hermana");
    }*/

    public void SetParentVehicle(Vehicle theVehicle)
    {
        parentVehicle = theVehicle;
    }

    public void SetMovingLimit(float mDistance)
    {
        whileMovingLimit = mDistance;
    }

    public void SetPhase(int _phase)
    {
        phase = _phase;
    }

    public void SetRotationVector(Vector3 rVector)
    {
        rotationVector = rVector;
    }

    public Vehicle GetParentVehicle()
    {
        return parentVehicle;
    }

    public float GetMovingLimit()
    {
        return whileMovingLimit;
    }

    public int GetPhase()
    {
        return phase;
    }

    public Vector3 GetRotationVector()
    {
        return rotationVector;
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
        SetParentVehicle(GetComponentInParent<Vehicle>());
        // translationVector = Vector3.zero;
        rotationVector = Vector3.zero;
        phase = 0;
    }

    public override void Think()
    {
        base.Think();
        RotationWhileMove();
        PendularMovement();
        PhaseController();
    }
}
