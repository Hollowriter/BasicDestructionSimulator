using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : PhysicsObj
{
    // Start is called before the first frame update
    void Start()
    {
        Initializing();
    }

    // Update is called once per frame
    void Update()
    {
        Think();
    }

    public override void Initializing()
    {
        base.Initializing();
    }

    public override void Think()
    {
        base.Think();
    }
}
