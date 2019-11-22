using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick2DUserControl : MonoBehaviour
{
    public float speed = 4.5f;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = transform.position.y;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
