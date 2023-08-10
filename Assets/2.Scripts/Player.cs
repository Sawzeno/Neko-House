using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform cam;
    private const float Speed = 0.05f;
    private float _ax;
    private float _ay;
    private float _az;
    private Vector3 _a;
    [SerializeField] private Vector3 init;

    private void Start()
    {
        cam.position = transform.position;
    }

    private void Update()
    {
        _ay += Input.GetAxis("Mouse X");
        _ax -= Input.GetAxis("Mouse Y");
        // _az += Input.GetAxis("Mouse ScrollWheel");

        cam.eulerAngles = new Vector3(_ax, _ay, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            cam.Translate(Vector3.forward * Speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            cam.Translate(Vector3.back * Speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            cam.Translate(Vector3.left * Speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            cam.Translate(Vector3.right * Speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            cam.Translate(Vector3.up * Speed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            cam.Translate(Vector3.down * Speed);
        }
    }
}