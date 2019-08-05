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
    int phase;

    public void RotationWhileMove()
    {
        // Debug.Log(GetDistance());
        if (GetDistance() > 0 && GetDistance() < maximumDistance ||
            GetDistance() < 0 && GetDistance() > maximumDistance * -1)
        {
            Debug.Log("entro");
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
            transform.Rotate(rotationVector);
        }
    }

    public void PendularMovement()
    {
        /*switch (phase)
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
        }*/ // Reparar esto
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
        PendularMovement();
    }
}
