using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour {

    [SerializeField]
    public Color _infectionColor;
    [SerializeField]
    private MeshRenderer _meshRenderer;

    public FXPresets fxPresets;

    public void Explode(float timeInSeconds) {
        _meshRenderer.material.color = _infectionColor;
        StartCoroutine(Exploding(timeInSeconds));
    }

    private IEnumerator Exploding(float timeInSeconds) {
        fxPresets.StartPreExplode(transform.position);
        yield return new WaitForSeconds(timeInSeconds);

        fxPresets.StartExplode(transform.position);
        Destroy(gameObject);
    }

}