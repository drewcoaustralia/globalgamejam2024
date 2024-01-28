using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float pickupDist = 1.5f;
    public float throwPower = 15f;
    public float throwAngle = -30f; // positive is towards floor, negative towards sky
    public float throwSpinMin = 30f;
    public float throwSpinMax = 60f;
    private Vector3 vel = Vector2.zero;
    private Vector3 lastVelocityDirection = Vector2.zero;
    public Transform pickupPosition;
    public List<float> raycastAngles = new List<float> { -30, -20, -10, 0, 10, 20, 30 };
    private GameObject closestChild = null;
    //private List<GameObject> foundChildren = new List<GameObject>();
    private bool handsEmpty = true;
    private GameObject heldObj = null;
    private ChildAnimationController _animationController;

    void Start()
    {
        _animationController = GetComponent<ChildAnimationController>();
    }

    void PerformRaycasts()
    {
        // Bit shift the index of the layer (7) to get a bit mask
        int layerMask = 1 << 7;

        RaycastHit hit;
        float closestDistanceTemp = Mathf.Infinity;
        GameObject closestChildTemp = null;
        //foundChildren.Clear();

        foreach (float angle in raycastAngles)
        {
            if (Physics.Raycast(transform.position, Quaternion.Euler(0, angle, 0) * lastVelocityDirection, out hit, pickupDist, layerMask))
            {
                if (hit.distance < closestDistanceTemp)
                {
                    closestDistanceTemp = hit.distance;
                    closestChildTemp = hit.transform.gameObject;
                }
                Debug.DrawRay(transform.position, Quaternion.Euler(0, angle, 0) * lastVelocityDirection * hit.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, Quaternion.Euler(0, angle, 0) * lastVelocityDirection * pickupDist, Color.white);
            }
        }

        if (closestChildTemp != null)
        {
            if (closestChild != null && closestChild != closestChildTemp)
            {
                closestChild.GetComponent<ChildAnimationController>().SetSelected(false);
            }
            closestChild = closestChildTemp;
            closestChild.GetComponent<ChildAnimationController>().SetSelected(true);
        }
        else
        {
            if (closestChild != null)
            {
                closestChild.GetComponent<ChildAnimationController>().SetSelected(false);
                closestChild = null;
            }
        }
    }

    void Update()
    {
        vel = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (vel.magnitude > 0f) _animationController.SetAnimation("walking");
        else _animationController.SetAnimation("idle");
        if (vel.sqrMagnitude > 1.0f) vel.Normalize();

        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            lastVelocityDirection = vel.normalized;
        }
        Vector3 lookDirection = transform.position + vel;
        lookDirection.z = transform.position.z;
        transform.LookAt(lookDirection);
        transform.position += vel * moveSpeed * Time.deltaTime;

        if (handsEmpty) PerformRaycasts();
        Debug.Log("raycasting with: " + closestChild);

        if (Input.GetKeyDown(KeyCode.Space)) Debug.Log("Space pressed");

        if (handsEmpty && closestChild != null && Input.GetKeyDown(KeyCode.Space))
        {
            handsEmpty = false;
            heldObj = closestChild;
            heldObj.transform.parent = transform;
            heldObj.transform.position = pickupPosition.position;
            heldObj.GetComponent<ChildAnimationController>().DisableBrains();
            heldObj.GetComponent<Rigidbody>().isKinematic = false;
            heldObj.GetComponent<Rigidbody>().useGravity = false;
            closestChild = null;
        }
        else if (!handsEmpty && heldObj != null && Input.GetKeyDown(KeyCode.Space))
        {
            handsEmpty = true;
            heldObj.transform.parent = null;
            heldObj.GetComponent<Rigidbody>().useGravity = true;
            heldObj.GetComponent<ChildAnimationController>().SetAnimation("flailing");
            Vector3 throwForce = throwPower * (Quaternion.AngleAxis(throwAngle, transform.TransformDirection(Vector3.right)) * transform.TransformDirection(Vector3.forward));
            heldObj.GetComponent<Rigidbody>().AddForce(throwForce,ForceMode.Impulse);
            float spin = Random.Range(throwSpinMin, throwSpinMax);
            heldObj.GetComponent<Rigidbody>().AddTorque(transform.right * spin, ForceMode.Impulse);
            heldObj = null;
        }
    }
}
