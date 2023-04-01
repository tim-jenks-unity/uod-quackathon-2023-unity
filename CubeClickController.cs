using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClickController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Hello Click!");
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo))
            {
                Debug.LogFormat("Hello Ray Intersection! {0}", 
                    hitInfo.collider.name);
                if (hitInfo.collider.TryGetComponent<Rigidbody>(out var rigidBody))
                {
                    rigidBody.AddForce(ray.direction * 200f);
                }
            }
        }
    }
}
