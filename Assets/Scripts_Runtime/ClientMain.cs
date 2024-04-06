using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TUNIC {

    public class ClientMain : MonoBehaviour {

        [SerializeField] RoleEntity roleEntity;

        MoudelInput input;
        void Awake() {
            input = new MoudelInput();
        }
        float restDT = 0;
        void Update() {
            float dt = Time.deltaTime;
            Vector2 moveAxis = Vector2.zero;

            if (Input.GetKey(KeyCode.W)) {
                moveAxis.y = 1;
            } else if (Input.GetKey(KeyCode.S)) {
                moveAxis.y = -1;
            }
            if (Input.GetKey(KeyCode.A)) {
                moveAxis.x = -1;
            } else if (Input.GetKey(KeyCode.D)) {
                moveAxis.x = 1;
            }
            input.moveAxis = moveAxis;
            restDT += dt;
            float fixedDT = Time.fixedDeltaTime;
            if (restDT >= fixedDT) {
                while (restDT >= fixedDT) {

                    FixedTick(fixedDT);

                    restDT -= fixedDT;
                }
            } else {
                FixedTick(restDT);
                restDT = 0;
            }


        }

        void FixedTick(float dt) {

            roleEntity.Move(input.moveAxis, dt);
            roleEntity.MoveFace(input.moveAxis, dt);

            Physics.Simulate(dt);
        }
    }
}