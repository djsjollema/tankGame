using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector2 maxSize;
    Vector2 minSize;

    Vector3 velocity;
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] float bearing = 0;


    void Start()
    {
        maxSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minSize = Camera.main.ScreenToWorldPoint(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Mathf.Cos(bearing * Mathf.Deg2Rad), Mathf.Sin(bearing * Mathf.Deg2Rad), 0);
        velocity = direction * speed;
        transform.position += velocity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, bearing);

        if(transform.position.x > maxSize.x)
        {
            transform.position = new Vector3(minSize.x, transform.position.y, 0);
        }

        if (transform.position.x < minSize.x)
        {
            transform.position = new Vector3(maxSize.x, transform.position.y, 0);
        }

        if (transform.position.y > maxSize.y)
        {
            transform.position = new Vector3(transform.position.x, minSize.y, 0);
        }

        if (transform.position.y < minSize.y)
        {
            transform.position = new Vector3(transform.position.x, maxSize.y, 0);
        }

    }
}
