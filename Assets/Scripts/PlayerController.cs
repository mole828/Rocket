using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private int _beforeFreeze;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        ProcessThrust();
    }

    public float rotateForce = 100f;
    public float thrustForce = 100f;
    private void Rotated(float force)
    {
        _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationZ;
        transform.Rotate(force * Time.deltaTime * Vector3.forward);
        _rigidbody.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
    }
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(thrustForce * Time.deltaTime * Vector3.up );
        }

        if (Input.GetKey(KeyCode.A))
        {
            Rotated(rotateForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Rotated(-rotateForce);
        }
    }
}
