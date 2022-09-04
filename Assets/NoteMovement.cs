using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    Vector2 init_pos;
    Vector2 init_scal;
    public float slideSpeed = 1.0f;
    public float lapNumber = 4.0f;
    const float Z_axisSpeed = 0.25f;
    float t = 0.0f;
    float s = 1.0f;
    const float sx = 2.837212f;
    const float sy = 4.786729f;
    const float max_r = 0.005f;
    const float r_scale = 0.007961f;
    // Start is called before the first frame update
    void Start()
    {
        init_pos = new Vector2(transform.position.x, transform.position.y);
        init_scal = new Vector3(transform.localScale.x * 0.1f, transform.localScale.y * 0.1f , 0.0f);
        transform.localScale = init_scal;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime * Z_axisSpeed);
    t += Time.deltaTime;
    if(t >= (lapNumber * 2.0f * Mathf.PI)){
        t = 0.0f;
        transform.position = init_pos;
        transform.localScale = init_scal;
    }
	transform.position = addAngle(transform.position, t, Mathf.Sqrt(t) * max_r);
    transform.localScale = new Vector3(transform.localScale.x * (1.0f + (Z_axisSpeed * Time.deltaTime)), transform.localScale.y * (1.0f + (Z_axisSpeed * Time.deltaTime)), 0.0f);

    transform.Rotate(0,0, Time.deltaTime * Mathf.Rad2Deg);

    }

    Vector2 addAngle(Vector2 vec, float angle, float length)
    {
        vec.x += Mathf.Cos(angle) * length;
        vec.y += Mathf.Sin(angle) * length;
        return vec;
        
    }
}
