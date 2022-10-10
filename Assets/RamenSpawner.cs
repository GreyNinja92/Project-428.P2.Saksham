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
    public bool isMoving = false;

    void Start()
    {
        Debug.Log("Starting a new object");
        isMoving = false;
        StartCoroutine(registerPosition());
        InvokeRepeating("spawnRamen", 2.0f, 3.0f);
    }

    IEnumerator registerPosition()
    {
        yield return new WaitForSeconds(1);
        lastPosition = ramen.transform.position;
        Debug.Log("Setting Initial Position " + lastPosition);
    }

    void spawnRamen() {
        Debug.Log("Current Position " + ramen.transform.position);
        if (ramen.transform.position != lastPosition) {
            isMoving = true;
            Debug.Log("Old pos " + ramen.transform.position);
            GameObject newObject = Instantiate(ramen, lastPosition, Quaternion.identity);
            Debug.Log("Instantiated new object");
            Debug.Log(newObject.transform.position);
            Destroy(GetComponent<RamenSpawner>());
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
