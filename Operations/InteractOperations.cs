using Systems.SimpleCore.Operations;

namespace Systems.SimpleInteract.Operations
{
    public sealed class InteractOperations
    {
        public const ushort SYSTEM_INTERACTION = 0x0007;

        public static OperationResult Permitted()
            => OperationResult.Success(SYSTEM_INTERACTION, OperationResult.SUCCESS_PERMITTED);
    }
}