using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bearing = 0;
    private float speed = 8f;
    Vector3 Velocity;
    Vector3 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Direction = new Vector3(Mathf.Cos(bearing * Mathf.Deg2Rad), Mathf.Sin(bearing * Mathf.Deg2Rad), 0);
        Velocity = Direction * speed;
        transform.position += Velocity * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, bearing);
    }
}
