using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 moveOffset;
    private Vector3 targetPos;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            if (targetPos == startPos)
            {
                targetPos = startPos + moveOffset;
            }
            else
            {
                targetPos = startPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().GameOver();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 from;
        Vector3 to;

        if (Application.isPlaying)
        {
            from = startPos;
            to = startPos + moveOffset;
        }
        else
        {
            from = transform.position;
            to = transform.position + moveOffset;
        }
        Gizmos.DrawLine(from, to);
        Gizmos.DrawWireSphere(from, .2f);
        Gizmos.DrawWireSphere(to, .2f);
    }


}
