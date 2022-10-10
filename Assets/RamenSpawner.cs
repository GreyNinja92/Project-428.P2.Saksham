using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamenSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ramen;
    public Vector3 origin = Vector3.zero;
    public float radius = 10;
    public Vector3 lastPosition = Vector3.zero;
    public Transform myTransform;
    public bool isMoving = false;

    void Start()
    {
        isMoving = false;
        StartCoroutine(registerPosition());
        InvokeRepeating("spawnRamen", 4.0f, 3.0f);
    }

    IEnumerator registerPosition()
    {
        yield return new WaitForSeconds(2);
        myTransform = ramen.transform;
        lastPosition = myTransform.position;
        Debug.Log("Initial Position " + lastPosition);
    }

    void spawnRamen() {
        Debug.Log("Current Position " + ramen.transform.position);
        if ( ramen.transform.position != lastPosition ) {
            isMoving = true;
            Debug.Log("Old pos " + ramen.transform.position);
            GameObject newObject = Instantiate(ramen, lastPosition, Quaternion.identity);
            lastPosition = newObject.transform.position;
            Debug.Log("Instantiated new object");
            Debug.Log(newObject.transform.position);
        } else {
            isMoving = false;
        }
        Debug.Log("isMoving = " + isMoving);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
