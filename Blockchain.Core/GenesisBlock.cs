using System;

namespace Blockchain.Core
{
    public class GenesisBlock : Block
    {
        public GenesisBlock() : base(
            previousHash: string.Empty,
            hash: "GenesisHash",
            timeStamp: DateTime.Parse("2021-02-05T10:46:00Z"), 
            data: "GenesisData")
        { }
    }
}