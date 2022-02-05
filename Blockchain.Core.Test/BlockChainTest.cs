using System.Linq;
using NUnit.Framework;

namespace Blockchain.Core.Test
{
    public class BlockChainTest
    {

        [Test]
        public void ConstructorTest()
        {
            var genesisHash = new GenesisBlock().Hash;
            var blockChain = new BlockChain();
            
            Assert.True(blockChain.Blocks.Count == 1);
            Assert.True(blockChain.Blocks.First().Hash == genesisHash);
        }

        [Test]
        public void AddBlockTest()
        {
            var genesisHash = new GenesisBlock().Hash;
            var blockChain = new BlockChain();
            var data1 = "data1";
            var data2 = "data2";

            var block1 = blockChain.AddBlock(data1);
            
            Assert.True(blockChain.Blocks.Count == 2);
            Assert.True(blockChain.Blocks.Last().Hash == block1.Hash);
            Assert.True(block1.PreviousHash == genesisHash);
            Assert.True(block1.Data == data1);

            var block2 = blockChain.AddBlock(data2);
            
            Assert.True(blockChain.Blocks.Count == 3);
            Assert.True(blockChain.Blocks.Last().Hash == block2.Hash);
            Assert.True(block2.PreviousHash == block1.Hash);
            Assert.True(block2.Data == data2);
        }
    }
}