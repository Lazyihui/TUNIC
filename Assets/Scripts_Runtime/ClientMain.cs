using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TUNIC {

    public class ClientMain : MonoBehaviour {

        [SerializeField] RoleEntity roleEntity;

        MoudelInput input;
        void Awake() {
            Debug.Log("ClientMain Awake");
            input = new MoudelInput();
        }

        void Update() {
            float dt = Time.deltaTime;
            Vector2 moveAxis = Vector2.zero;

            if (Input.GetKey(KeyCode.W)) {
                moveAxis.y = 1;
            } else if (Input.GetKey(KeyCode.S)) {
                Debug.Log("S");
                moveAxis.y = -1;
            }
            if (Input.GetKey(KeyCode.A)) {
                moveAxis.x = -1;
            } else if (Input.GetKey(KeyCode.D)) {
                moveAxis.x = 1;
            }
            // 左右和上下要分开写
            moveAxis.Normalize();
            roleEntity.transform.position += new Vector3(moveAxis.x, 0, moveAxis.y) * dt * 5;
            Debug.Log(roleEntity.transform.position);
        }
    }
}