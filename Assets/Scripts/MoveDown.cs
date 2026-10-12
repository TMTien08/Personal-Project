using UnityEngine;
using UnityEngine.UIElements;

public class MoveDown : MonoBehaviour
{
    public float speed;
    private float zDestroy = -15;
    private Rigidbody objectRb;
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Vector3 position = objectRb.position + Vector3.back *  Time.deltaTime * speed;
        objectRb.MovePosition(position);
    }
}
