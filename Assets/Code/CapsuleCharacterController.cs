using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CapsuleCharacterController : MonoBehaviour
{
    Rigidbody rb;
    Material capsuleMat;
    Color baseColor;
    List<(Color, float)> colorWeights;
    [SerializeField]
    float affectedTime = 1; 

    [SerializeField]
    float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleMat = GetComponent<MeshRenderer>().material;
        baseColor = capsuleMat.color;
        colorWeights = new List<(Color, float)>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forwardVector = Camera.main.transform.forward;
        forwardVector-=forwardVector.y*Vector3.up;
        rb.velocity = (forwardVector*Input.GetAxis("Vertical") + Camera.main.transform.right*Input.GetAxis("Horizontal"))*Speed;
        if(colorWeights.Count == 0)
        {
            capsuleMat.color = baseColor;
            return;
        }
        float r = 0;
        float g = 0;
        float b = 0;
        float totalTime = 0;
        for (int i = colorWeights.Count-1; i >= 0; i--)
        {
            float newTime = colorWeights[i].Item2 - Time.fixedDeltaTime;
            if (newTime <= 0)
            {
                colorWeights.RemoveAt(i);
                continue;
            }
            colorWeights[i] = (colorWeights[i].Item1, newTime);
            r+=colorWeights[i].Item1.r * colorWeights[i].Item2;
            g+=colorWeights[i].Item1.g * colorWeights[i].Item2;
            b+=colorWeights[i].Item1.b * colorWeights[i].Item2;
            totalTime += newTime;
        }   
        capsuleMat.color = new Color(r/totalTime, g/totalTime, b/totalTime);
    }
    void OnTriggerEnter(Collider collider)
    {
        print(collider.gameObject.name);
        for (int i = 0; i < colorWeights.Count ; i++)
        {
            if(colorWeights[i].Item1 == collider.GetComponent<Light>().color)
            {
                colorWeights[i] = (colorWeights[i].Item1, affectedTime);
                return;
            }
        }
        colorWeights.Add((collider.GetComponent<Light>().color, affectedTime));
    }
}
