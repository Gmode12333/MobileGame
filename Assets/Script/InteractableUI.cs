using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    private RectTransform transform;
    void Start()
    {
        transform = GetComponent<RectTransform>();
    }
    public void StartInteract()
    {
        StartCoroutine(OnInteractUI());
    }
    public void OnInteract()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    public void OffInteract()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    IEnumerator OnInteractUI()
    {
        OnInteract();
        yield return new WaitForSeconds(0.2f);
        OffInteract();
    }
}
