using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : PhysicsObj
{
    void Start()
    {
        Initializing();
    }

    void Update()
    {
        Think();
    }

    public override void Think()
    {
        base.Think();
    }

    public override void Initializing()
    {
        base.Initializing();
    }
}
