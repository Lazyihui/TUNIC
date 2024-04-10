namespace TUNIC {
    public class GameContext {


        public int ownerRoleID;
        public MoudelInput input;

        public ModuleAsstes asstes;

        public IDService idService;

        public RoleRepository roleRepository;

        public GameContext() {
            idService = new IDService();
            roleRepository = new RoleRepository();
        }


        public void Inject(ModuleAsstes asstes, MoudelInput input) {
            this.asstes = asstes;
            this.input = input;
        }

    }

}