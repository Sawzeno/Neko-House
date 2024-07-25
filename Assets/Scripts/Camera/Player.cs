using UnityEngine;

public class Player : MonoBehaviour
{
    private float Speed = 0.05f;
    private float _ax;
    private float _ay;
    private void Update()
    {
        _ay += Input.GetAxis("Mouse X");
        _ax -= Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(_ax, _ay, 0f);


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector3.up * Speed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.down * Speed);
        }

        if(Input.GetKey(KeyCode.LeftShift)){
            Speed += 0.01f;
        }
        if(Input.GetKey(KeyCode.RightShift)){
            Speed -= 0.01f;
        }
    }
}