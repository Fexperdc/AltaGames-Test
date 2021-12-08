using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushGenerator : MonoBehaviour {

    [SerializeField]
    private Vector2 areaRect;

    [SerializeField]
    private GameObject _bush;

    [SerializeField]
    private int bushCount;

    [SerializeField][Header("FX")]
    private FXPresets _fxPresets;

    private void Awake() {
        Generate();
    }

    public void Generate() {
        for(int i = 0; i < bushCount; i++) {
            var bush = Instantiate(_bush);
            bush.GetComponent<Bush>().fxPresets = _fxPresets;
            bush.transform.position = transform.position + new Vector3(Random.Range(-(areaRect.x / 2), areaRect.x / 2), 0, Random.Range(-(areaRect.y / 2), areaRect.y / 2));
        }
    }

    private void OnDrawGizmos() {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, areaRect);
    }

}
