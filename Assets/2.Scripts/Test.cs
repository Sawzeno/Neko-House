using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]private Transform cube;
    [SerializeField][Range(1f,1000f)]private float rotateSpeed = 900f; 
    private void Start()
    {
        Debug.Log(cube.eulerAngles);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            Debug.Log("H");
            var angle = rotateSpeed * Time.deltaTime;
            
            cube.rotation *= Quaternion.AngleAxis(angle , Vector3.up);
        }

        if (Input.GetKey(KeyCode.J))
        {
            cube.eulerAngles += new Vector3(0f, 10f, 0f) * Time.deltaTime;

        }

        if (Input.GetKey(KeyCode.K))
        {
            Vector3 mousePos = Vector3.zero;
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            mousePos.z = Input.mousePosition.z;
            
            cube.eulerAngles = new Vector3(mousePos.x, mousePos.y, mousePos.z) ;

        }
    }

}
