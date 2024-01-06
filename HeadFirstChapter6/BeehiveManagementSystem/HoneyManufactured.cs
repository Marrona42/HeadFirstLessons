using System;

namespace BeehiveManagementSystem
{
    class HoneyManufactured : Bee
    {
        public const float NECTAR_COLLECTED_PER_SHIFT = 33.15f;
        public override float CostPerShift { get { return 1.7f; } }
        public HoneyManufactured() : base("Honey Manufactured") { }

        protected override void DoJob()
        {
            HoneyVaultBase.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
