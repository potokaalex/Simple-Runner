using UnityEngine;
using Ecs;


public class MoveForward : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        //перейти к векторам ! 
        
        var tW = (Vector3.zero - transform.rotation.eulerAngles) * 90;
        var tA = (Vector3.down - transform.rotation.eulerAngles) * 90;

        if (Input.GetKeyDown(KeyCode.W))
            transform.rotation = Quaternion.Euler(tW);

        if (Input.GetKeyDown(KeyCode.A))
            transform.rotation = Quaternion.Euler(tA);
    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector3.forward * Speed * Time.fixedDeltaTime);
    }
}