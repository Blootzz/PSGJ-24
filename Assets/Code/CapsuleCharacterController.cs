using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CapsuleCharacterController : MonoBehaviour
{
    CharacterController characterController;
    Material capsuleMat;
    Color baseColor;
    [SerializeField]
    float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        capsuleMat = GetComponent<MeshRenderer>().material;
        baseColor = capsuleMat.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move*Speed);
    }
    void OnTriggerEnter(Collider collider)
    {
        print(collider.gameObject.name);
        capsuleMat.color = collider.GetComponent<Light>().color;
    }
    void OnTriggerExit(Collider collider)
    {
        capsuleMat.color = baseColor;
    }
}
