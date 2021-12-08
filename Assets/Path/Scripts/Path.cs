using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    [SerializeField]
    private SphereShooting _sphereShooting;
    [SerializeField]
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private Color _hasColor;
    [SerializeField]
    private Color _doesNotHaveColor;

    public Vector3 size;
    private bool _hasObstacles = true;

    private void Awake() {
        StartCoroutine(ObstacleChecking());
    }

    private void Update() {
        transform.localScale = _sphereShooting.transform.localScale;
    }

    public IEnumerator ObstacleChecking() {
        while(true) {
            yield return new WaitForSeconds(0.5f);
            if(GetObstacles().Count > 0) {
                _hasObstacles = true;
                _meshRenderer.material.color = _hasColor;
            } else {
                _hasObstacles = false;
                _meshRenderer.material.color = _doesNotHaveColor;
            }
        }
    }

    public List<GameObject> GetObstacles() {
        List<GameObject> gameObjects = new List<GameObject>();
        foreach(Collider collider in Physics.OverlapBox(transform.position, Vector3.Scale(size, _sphereShooting.transform.localScale) / 2)) {
            if(collider.gameObject.TryGetComponent(out Bush bush)) {
                gameObjects.Add(collider.gameObject);
            }
        }
        return gameObjects;
    }

    public bool HasObstacles => _hasObstacles;

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, Vector3.Scale(size, _sphereShooting.transform.localScale));
    }

}