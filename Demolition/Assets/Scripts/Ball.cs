using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : PhysicsObj
{
    Vehicle parentVehicle;
    Vector3 translationVector;
    [SerializeField]
    float maximumDistance;

    void SetParentVehicle(Vehicle theVehicle)
    {
        parentVehicle = theVehicle;
    }

    void SetMaximumDistance(float mDistance)
    {
        maximumDistance = mDistance;
    }

    Vehicle GetParentVehicle()
    {
        return parentVehicle;
    }

    float GetMaximumDistance()
    {
        return maximumDistance;
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
        translationVector = Vector3.zero;
    }

    public override void Think()
    {
        base.Think();
    }
}
