using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 axis;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetAxis(Vector2 axis)
    {
        this.axis = axis;
        animator.SetFloat("Speed", axis.magnitude);
        StopCoroutine("Move");
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        while (axis.magnitude > 0f)
        {
            float horizontal = axis.x;
            float vertical = axis.y;

            transform.Translate(Vector3.forward * vertical * Time.deltaTime * moveSpeed);
            transform.Rotate(Vector3.up * horizontal, Space.World);
            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }

}
