using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : PhysicsObj
{
    // Vehicle parentVehicle;
    // Vector3 translationVector;
    Vector3 rotationVector;
    [SerializeField]
    float maximumDistance;
    [SerializeField]
    float maximumRotation;
    int phase;

    public void RotationWhileMove()
    {
        Debug.Log("Angulo = " + GetRotationAngle());
        Debug.Log("DistanciaMaxima = " + GetMaximumDistance());
        if (GetDistance() > 0 /*&& GetDistance() < maximumDistance*/ ||
            GetDistance() < 0 /*&& GetDistance() > maximumDistance * -1*/)
        {
            switch (phase)
            {
                case 0:
                    if (GetTime() > 0)
                    {
                        SetTime(GetTime() - 1);
                    }
                    break;
                case 1:
                    rotationVector.z = GetEndVelocity();
                    break;
                case 2:
                    rotationVector.z = GetEndVelocity() * -1;
                    break;
            }
            if (GetDistance() > 0 && GetRotationAngle() > maximumRotation * -1 ||
                GetDistance() < 0 && GetRotationAngle() < maximumRotation)
            {
                transform.Rotate(rotationVector);
            }
        }
    }

    public void PendularMovement()
    {
        switch (phase)
        {
            case 0:
                if (GetTime() > 0)
                {
                    SetTime(GetTime() - 1);
                    Debug.Log(GetTime());
                }
                break;
        }
        if (GetDistance() == 0)
        {
            transform.Rotate(rotationVector);
        }
    }

    /*public void Translation(Vector3 consecuence)
    {
        transform.Translate(consecuence * Time.deltaTime);
        Debug.Log("chupamela, la concha de tu hermana");
    }*/

    /*public void SetParentVehicle(Vehicle theVehicle)
    {
        parentVehicle = theVehicle;
    }*/

    public void SetMaximumDistance(float mDistance)
    {
        maximumDistance = mDistance;
    }

    public void SetPhase(int _phase)
    {
        phase = _phase;
    }

    public void SetRotationVector(Vector3 rVector)
    {
        rotationVector = rVector;
    }
    /*public Vehicle GetParentVehicle()
    {
        return parentVehicle;
    }*/

    public float GetMaximumDistance()
    {
        return maximumDistance;
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
        // SetParentVehicle(GetComponentInParent<Vehicle>());
        // translationVector = Vector3.zero;
        rotationVector = Vector3.zero;
        phase = 0;
    }

    public override void Think()
    {
        base.Think();
        RotationWhileMove();
        // PendularMovement();
    }
}
