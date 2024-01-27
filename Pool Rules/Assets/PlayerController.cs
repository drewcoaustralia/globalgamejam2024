using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float pickupDist = 1f;
    public float throwPower = 1f;
    public float throwAngle = 30f; // positive is towards floor, negative towards sky
    public float throwSpinMin = 30f;
    public float throwSpinMax = 90f;
    private Vector3 velocity = Vector2.zero;
    public BoxCollider boxcaster;
    public Transform pickupPosition;
    private GameObject raycastHitObj = null;
    private bool handsEmpty = true;
    private GameObject heldObj = null;

    void Start()
    {
        
    }

    void PerformRaycast()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;

        if (handsEmpty && Physics.BoxCast(boxcaster.bounds.center, boxcaster.transform.localScale * 0.5f, transform.forward, out hit, transform.rotation, pickupDist, layerMask))
        //if (handsEmpty && Physics.Raycast(raycastOrigin.position, transform.TransformDirection(Vector3.forward), out hit, pickupDist/*, layerMask*/))
        {
            Debug.DrawRay(boxcaster.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (raycastHitObj != null && raycastHitObj != hit.transform.gameObject)
            {
                raycastHitObj.GetComponent<ChildAnimationController>().SetSelected(false);
            }
            raycastHitObj = hit.transform.gameObject;
            raycastHitObj.GetComponent<ChildAnimationController>().SetSelected(true);
        }
        else
        {
            Debug.DrawRay(boxcaster.transform.position, transform.TransformDirection(Vector3.forward) * pickupDist, Color.white);
            if (raycastHitObj != null)
            {
                raycastHitObj.GetComponent<ChildAnimationController>().SetSelected(false);
                raycastHitObj = null;
            }
        }
    }

    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        Vector3 lookDirection = transform.position + velocity;
        lookDirection.z = transform.position.z;
        transform.LookAt(lookDirection);
        transform.position += velocity * Time.deltaTime;

        if (handsEmpty) PerformRaycast();

        if (Input.GetKeyDown(KeyCode.Space)) Debug.Log("Space pressed");

        if (handsEmpty && raycastHitObj != null && Input.GetKeyDown(KeyCode.Space))
        {
            handsEmpty = false;
            heldObj = raycastHitObj;
            heldObj.GetComponent<ChildAnimationController>().SetSelected(false);
            heldObj.transform.parent = transform;
            heldObj.transform.position = pickupPosition.position;
            heldObj.GetComponent<Rigidbody>().useGravity = false;
            raycastHitObj = null;
        }
        else if (!handsEmpty && heldObj != null && Input.GetKeyDown(KeyCode.Space))
        {
            handsEmpty = true;
            heldObj.transform.parent = null;
            heldObj.GetComponent<Rigidbody>().useGravity = true;
            heldObj.GetComponent<ChildAnimationController>().StartAnimating();
            Vector3 throwForce = throwPower * (Quaternion.AngleAxis(throwAngle, transform.TransformDirection(Vector3.right)) * transform.TransformDirection(Vector3.forward));
            Debug.Log(throwForce);
            heldObj.GetComponent<Rigidbody>().AddForce(throwForce,ForceMode.Impulse);
            float spin = Random.Range(throwSpinMin, throwSpinMax);
            heldObj.GetComponent<Rigidbody>().AddTorque(transform.right * spin, ForceMode.Impulse);
            heldObj = null;
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(boxcaster.transform.position, transform.TransformDirection(Vector3.forward) * pickupDist, Color.white);
    }
}
