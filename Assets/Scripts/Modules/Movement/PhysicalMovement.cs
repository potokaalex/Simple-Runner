using System.Collections;
using UnityEngine;
using System;


public class PhysicalMovement : MonoBehaviour
{
    [SerializeField] PhysicalEntity physicalEntity;
    [SerializeField] private float directionSpeed;
    [SerializeField] private float turnSpeed;

    private float accelerationModify;

    public void Move(Vector3 direction)
    {
        //  var _normal = Vector3.zero;//character.LastContact.normal;
        // var _directionAlongSurface = direction - Vector3.Dot(direction, _normal) * _normal;
        // var _offset = _directionAlongSurface * (directionSpeed + accelerationModify) * Time.deltaTime;

        // character.rigidbody.AddRelativeForce(direction.normalized * directionSpeed, ForceMode.VelocityChange);// =  * Time.deltaTime;

        //character.rigidbody.AddForce(direction * directionSpeed * Time.deltaTime);
        //character.transform.Translate();
    }

    public void Rotate(Vector3 axis)
        => physicalEntity.transform.Rotate(axis, turnSpeed * Time.deltaTime);

    public void ApplySpeedAcceleration(float forse, float time)
    {
        accelerationModify = forse;

        StartCoroutine(DelayTask(time, () => accelerationModify = 0));
    }

    IEnumerator DelayTask(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task?.Invoke();
    }
}