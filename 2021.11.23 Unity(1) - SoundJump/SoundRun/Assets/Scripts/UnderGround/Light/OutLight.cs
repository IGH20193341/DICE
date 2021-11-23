using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLight : MonoBehaviour
{
    Light Light;
    // Start is called before the first frame update
    void Start()
    {
        Light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Light.color = Color.white;
        transform.Rotate(100, 0, 0);
    }
}
