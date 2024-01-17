using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTranforms : MonoBehaviour
{
    public float MoveSpeed;
    private void Start()
    {
        StartCoroutine(MoveTransforms());
    }
    IEnumerator MoveTransforms()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            this.gameObject.transform.position += new Vector3(0, -MoveSpeed, 0);
        }
    }
}
