using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public float moveSpeed = 1f;
    [SerializeField]float rotateSpeed;

    private void Update()
    {
        transform_rot();
    }

    void transform_rot()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sise"))
        {
            buttonclick.instance.isknife = false;
            Destroy(gameObject,0.5f);
            buttonclick.instance.selectdelete(other.gameObject);
            
        }
    }
}
