using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObj : MonoBehaviour
{
    float lastPosition;
    float initialVelocity;
    float endVelocity;
    float time;
    [SerializeField]
    float acceleration; // (endVelocity - initialVelocity) / (endTime - initialTime)
    [SerializeField]
    float mass;
    float strength; // mass * acceleration
    float weight; // mass * gravity
    float distance;
    float work; // strength * distance
    [SerializeField]
    float maxVelocity;
    [SerializeField]
    static float gravity;

    public void UpdateVelocity()
    {
        endVelocity = initialVelocity + acceleration * time;
        initialVelocity = endVelocity;
        endVelocity = maxVelocity;
        initialVelocity = maxVelocity;
    }

    public void UpdateDistance()
    {
        distance = transform.position.x - lastPosition;
    }

    public void ReubicateLastPosition()
    {
        lastPosition = transform.position.x;
    }

    public void UpdateWork()
    {
        work = strength * distance;
    }
    public void SetTime(float newTime)
    {
        time = newTime;
    }
    public float GetLastPosition()
    {
        return lastPosition;
    }
    public float GetInitialVelocity()
    {
        return initialVelocity;
    }
    public float GetEndVelocity()
    {
        return endVelocity;
    }
    public float GetStrength()
    {
        strength = mass * acceleration;
        return strength;
    }
    public float GetWeight()
    {
        weight = mass * gravity;
        return weight;
    }
    public float GetWork()
    {
        return work;
    }
    public float GetTime()
    {
        return time;
    }
    public float GetAcceleration()
    {
        return acceleration;
    }
    public float GetDistance()
    {
        return distance;
    }
    public float GetMass()
    {
        return mass;
    }
    public float GetGravity()
    {
        return gravity;
    }
    public float GetMaxVelocity()
    {
        return maxVelocity;
    }

    void Start()
    {
        Initializing();
    }

    void Update()
    {
        Think();
    }

    public virtual void Initializing()
    {
        lastPosition = transform.position.x;
        initialVelocity = 0;
        endVelocity = 0;
        time = 0;
        strength = mass * acceleration;
        weight = mass * gravity;
        distance = transform.position.x - lastPosition;
    }

    public virtual void Think()
    {
        UpdateVelocity();
        UpdateDistance();
        UpdateWork();
        /*Debug.Log("InitialVelocity: " + GetInitialVelocity() + "/n");
        Debug.Log("EndVelocity: " + GetEndVelocity() + "/n");
        Debug.Log("LastPosition: " + GetLastPosition() + "/n");
        Debug.Log("Strength: " + GetStrength() + "/n");
        Debug.Log("Mass: " + GetMass() + "/n");
        Debug.Log("Weight: " + GetWeight() + "/n");
        Debug.Log("Acceleration: " + GetAcceleration() + "/n");
        Debug.Log("Distance: " + GetDistance() + "/n");
        Debug.Log("Time: " + GetTime() + "/n");
        Debug.Log("Work: " + GetWork() + "/n");
        Debug.Log("MaxVelocity: " + GetMaxVelocity() + "/n");*/
    }
}
