using System;

namespace Blockchain.Core
{
    public class GenesisBlock : Block
    {
        private static string previousHash = string.Empty;
        private static string data = "Genes1s_d4t4.!";
        private static DateTime timeStamp = DateTime.Parse("2021-02-05T10:46:00Z"); 
        
        public GenesisBlock() : base(
            previousHash: previousHash,
            hash: ComputeHash(timeStamp, previousHash, data),
            timeStamp: timeStamp, 
            data: data)
        { }
    }
}