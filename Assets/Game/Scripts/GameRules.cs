using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour {

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Path _path;
    [SerializeField]
    private float _minimumScale;

    private SphereShooting _playerSphereShooting;

    private void Awake() {
        _playerSphereShooting = _player.GetComponent<SphereShooting>();
    }

    private void Update() {
        if(_player.transform.localScale.x <= _minimumScale) {
            RestartGame();
        }
        if(Input.GetKey(KeyCode.Space) || Input.touchCount > 0) {
            _playerSphereShooting.PreShooting();
        }
        if(Input.GetKeyUp(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) {
            _playerSphereShooting.Shoot();
        }
    }

    private void FixedUpdate() {
        if(_path.HasObstacles == false) {
            _player.GetComponent<Rigidbody>().AddForce(Vector3.forward * 20, ForceMode.Acceleration);
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
