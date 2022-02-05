using System.Collections.Generic;
using System.Linq;

namespace Blockchain.Core
{
    public class BlockChain
    {
        internal List<Block> Blocks;

        public BlockChain()
        {
            Blocks = new List<Block>() { new GenesisBlock() };
        }

        public Block AddBlock(string data)
        {
            var newBlock = Blocks.Last().Mine(data);
            Blocks.Add(newBlock);
            return newBlock;
        }
    }
}