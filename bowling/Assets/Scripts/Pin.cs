using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    float timer;

    void Update()
    {
        if (transform.rotation.eulerAngles.z <= -70 || transform.rotation.eulerAngles.z >= 70 || transform.rotation.eulerAngles.x <= -70 || transform.rotation.eulerAngles.x >= 70)
        {
            timer += Time.deltaTime;
            if (timer > 2f)
            {
                timer = 0f;
                PinManager.Instance.AddDisablePinCount();
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
