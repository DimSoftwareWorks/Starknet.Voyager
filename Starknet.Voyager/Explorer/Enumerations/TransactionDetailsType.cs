using System.Runtime.Serialization;

namespace Starknet.Voyager.Explorer.Enumerations
{
    public enum TransactionDetailsType
    {
        /// <summary>
        /// Indicates a contract deployment. 
        /// </summary>
        [EnumMember(Value = "DEPLOY")]
        Deploy = 0,

        /// <summary>
        /// Indicates a contract call.
        /// <summary>
        [EnumMember(Value = "INVOKE")]
        Invoke,

        /// <summary>
        /// Indicates a class declaration
        /// <summary>
        [EnumMember(Value = "DECLARE")]
        Declare,

        /// <summary>
        /// Indicates an interaction with the L1.
        /// <summary>
        [EnumMember(Value = "L1_HANDLER")]
        L1Handler,

        /// <summary>
        /// Indicates an account creation.
        /// <summary>
        [EnumMember(Value = "DEPLOY_ACCOUNT")]
        DeployAccount
    }
}
