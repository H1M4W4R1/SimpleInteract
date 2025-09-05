using Systems.SimpleCore.Operations;

namespace Systems.SimpleInteract.Operations
{
    public sealed class InteractOperations
    {
        public const ushort SYSTEM_INTERACTION = 0x0007;
        
        public const ushort ERROR_NO_OBJ_IN_RANGE = 0x0001;

        public const ushort SUCCESS_INTERACTED = 0x0001;
        
        public static OperationResult Permitted()
            => OperationResult.Success(SYSTEM_INTERACTION, OperationResult.SUCCESS_PERMITTED);
        
        public static OperationResult Denied()
            => OperationResult.Error(SYSTEM_INTERACTION, OperationResult.ERROR_DENIED);
        
        public static OperationResult NoObjectsInRange()
            => OperationResult.Error(SYSTEM_INTERACTION, ERROR_NO_OBJ_IN_RANGE);
        
        public static OperationResult Interacted()
            => OperationResult.Success(SYSTEM_INTERACTION, SUCCESS_INTERACTED);
    }
}