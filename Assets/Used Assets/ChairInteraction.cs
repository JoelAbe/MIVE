using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChairInteraction : XRGrabInteractable
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Transform originalParent;
    private bool isSitting = false;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        if (!isSitting)
        {
            // Store original position, rotation, and parent
            originalPosition = transform.position;
            originalRotation = transform.rotation;
            originalParent = transform.parent;

            // Attach the chair to the interactor (hand/controller)
            transform.parent = interactor.transform;

            // Disable physics simulation for the chair
            Rigidbody chairRigidbody = GetComponent<Rigidbody>();
            if (chairRigidbody != null)
                chairRigidbody.isKinematic = true;

            // Align the user's camera with the chair's position
            Vector3 offset = interactor.transform.position - originalPosition;
            XRRig xrRig = interactor.GetComponentInParent<XRRig>();

        }
    }
}
