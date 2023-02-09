using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed = 180.0f;
    public int collectPoints = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision Detected");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().AddScore(collectPoints);
            Destroy(gameObject);
        }
    }
}
