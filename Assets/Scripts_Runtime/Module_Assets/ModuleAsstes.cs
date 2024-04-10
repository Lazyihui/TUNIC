using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TUNIC {


    public class ModuleAsstes {

        Dictionary<string, GameObject> entities;
        AsyncOperationHandle entityPtr;

        public ModuleAsstes() {
            entities = new Dictionary<string, GameObject>();
        }

        public void Load(){

            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "Entity";
                var ptr = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var list = ptr.WaitForCompletion();
                foreach (var entity in list) {
                    entities.Add(entity.name, entity);
                }
                this.entityPtr = ptr;
            }
        }

        public void UnLoad(){
            if(entityPtr.IsValid()){
                Addressables.Release(this.entityPtr);
            }
        }
        public bool TryGetEntity(string name, out GameObject entity) {
            return entities.TryGetValue(name, out entity);
        }


    }
}
