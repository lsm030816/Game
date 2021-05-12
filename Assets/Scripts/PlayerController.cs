using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public IEnumerator Move(Vector2 axis)
    {
        while (true)
        {
            float horizontal = axis.x;
            float vertical = axis.y;

            transform.Translate(Vector3.forward * vertical * Time.deltaTime * 5f);
            transform.Rotate(Vector3.up * horizontal, Space.World);
            yield return new WaitForFixedUpdate();
        }

    }

}
