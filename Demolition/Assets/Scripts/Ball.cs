using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : PhysicsObj
{
    // Vehicle parentVehicle;
    Vector3 rotationVector;
    [SerializeField]
    float maximumDistance;
    int phase;

    public void Movement()
    {
        if (GetDistance() < maximumDistance) // Rodrigo, mas te vale revisar esto porque es raro
        { // Y trata de ver porque el objeto no va a la misma velocidad que el padre.
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
            transform.Rotate(rotationVector);
        }
    }

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
        rotationVector = Vector3.zero;
        phase = 0;
    }

    public override void Think()
    {
        base.Think();
        Movement();
    }
}
