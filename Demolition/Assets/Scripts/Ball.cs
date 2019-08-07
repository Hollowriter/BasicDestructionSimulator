using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : PhysicsObj
{
    Vehicle parentVehicle;
    // Vector3 translationVector;
    Vector3 rotationVector;
    /*[SerializeField]
    float whileMovingLimit;*/
    [SerializeField]
    float maximumRotation;
    int phase;
    bool colliding;

    public void RotationWhileMove()
    {
        if (GetDistance() > 0 || GetDistance() < 0)
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
                GetRotationAngle() > maximumRotation * -1 && GetColliding() == false ||
                parentVehicle.GetDistance() < 0 && 
                GetRotationAngle() < maximumRotation && GetColliding() == false)
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
                    SetTime(0);
                    break;
                case 4:
                    SetPhase(3);
                    SetTime(0);
                    break;
            }
        }
    }

    public void SetParentVehicle(Vehicle theVehicle)
    {
        parentVehicle = theVehicle;
    }

    public void SetColliding(bool coll)
    {
        colliding = coll;
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

    public bool GetColliding()
    {
        return colliding;
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
        rotationVector = Vector3.zero;
        colliding = false;
        phase = 0;
    }

    public override void Think()
    {
        base.Think();
        RotationWhileMove();
        PendularMovement();
        PhaseController();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
            if (GetStrength() > collision.gameObject.GetComponent<Breakable>().GetWeight())
            {
                Destroy(collision.gameObject);
                Debug.Log("MiFuerza = " + GetStrength());
                Debug.Log("ElPesoDelObjeto = " + collision.gameObject.GetComponent<Breakable>().GetWeight());
            }
            else
            {
                if (GetPhase() == 4)
                {
                    SetTime(0);
                    SetPhase(3);
                }
                else if (GetPhase() == 1)
                {
                    SetTime(0);
                    SetColliding(true);
                }
            }
            Debug.Log("MiFuerza = " + GetStrength());
            Debug.Log("ElPesoDelObjeto = " + collision.gameObject.GetComponent<Breakable>().GetWeight());
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Breakable")
        {
            if (GetStrength() < other.gameObject.GetComponent<Breakable>().GetWeight())
            {
                if (GetPhase() == 1)
                {
                    SetTime(0);
                    SetColliding(true);
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Breakable")
        {
            SetColliding(false);
        }
    }
}
