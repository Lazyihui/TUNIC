using System.Collections;
using UnityEngine;


namespace TUNIC {

    public static class GameFactory {

        public static RoleEntity Role_Create(ModuleAsstes asstes, int typeID,IDService idService) {
            bool has = asstes.TryGetEntity("Entity_Role",out var go);

            if(!has){
                Debug.LogError("Entity_Role not found");
                return null;
            }
            go = GameObject.Instantiate(go);
            RoleEntity role = go.GetComponent<RoleEntity>();
            role.id = idService.roleIDRecord++;
            role.Ctor();
            role.Init();
            return role;
            


        }
    }
}