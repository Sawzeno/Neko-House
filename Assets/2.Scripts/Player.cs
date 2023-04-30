using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform cam;
    private float speed = 0.05f;
    private float _ax ;
    private float _ay ;
    private float _az ;
    private Vector3 _a;
    readonly Vector3 _init = Vector3.zero;

    private void Start()
    {
        cam.position = _init;
    }

    private void Update()
    {
        _ay += Input.GetAxis("Mouse X");
        _ax -= Input.GetAxis("Mouse Y");
        // _az += Input.GetAxis("Mouse ScrollWheel");

        cam.eulerAngles = new Vector3(_ax, _ay, 0f);

        if (Input.GetKey(KeyCode.W))
        {
            cam.Translate(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cam.Translate(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            cam.Translate(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cam.Translate(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cam.Translate(Vector3.up * speed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            cam.Translate(Vector3.down * speed);
        }
    }
}
