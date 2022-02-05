using System;
using NUnit.Framework;

namespace Blockchain.Core.Test
{
    public class BlockTest
    {
        [Test]
        public void ConstructorTest()
        {
            var timeStamp = DateTime.UtcNow;
            var data = "data";
            var previousHash = "previousHash";

            var block1 = new Block(previousHash: previousHash, timeStamp: timeStamp, data: data);
            Assert.True(block1.TimeStamp == timeStamp);
            Assert.True(block1.Data == data);
            Assert.True(block1.PreviousHash == previousHash);

            var hash = block1.Hash;
            var block2 = new Block(previousHash: previousHash, timeStamp: timeStamp, data: data, hash: hash);
            Assert.True(block1.TimeStamp == timeStamp);
            Assert.True(block1.Data == data);
            Assert.True(block1.PreviousHash == previousHash);
            Assert.True(block1.Hash == hash);

            try
            {
                var block3 = new Block(previousHash: previousHash, timeStamp: timeStamp, data: data, hash: "hash");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.True(e.Message.Contains("Invalid Hash"));   
            }
            
            var block4 = new Block(previousHash, timeStamp, data);
            var block5 = new Block(previousHash, timeStamp, data);
            
            Assert.True(block4.Hash == block5.Hash);
        }

        [Test]
        public void MineTest()
        {
            var timeStamp = DateTime.UtcNow;
            var data = "data";
            var previousHash = "previousHash";
            var previousBlock = new Block(previousHash, timeStamp, data);

            var data2 = "data2";
            var minedBock = previousBlock.Mine(data2);
            
            Assert.True(minedBock.PreviousHash == previousBlock.Hash);
            Assert.True(minedBock.TimeStamp > timeStamp);
            Assert.True(minedBock.Data == data2);
        }

        [Test]
        public void ComputeHashTest()
        {
            var timeStamp = DateTime.UtcNow;
            var data = "data";
            var previousHash = "previousHash";

            var hash1 = Block.ComputeHash(timeStamp, previousHash, data);
            var hash2 = Block.ComputeHash(timeStamp, previousHash, data);
            var hash3 = Block.ComputeHash(timeStamp, previousHash, data.Substring(0,1));
            var hash4 = Block.ComputeHash(timeStamp, previousHash.Substring(0,1), data);
            var hash5 = Block.ComputeHash(timeStamp.AddMilliseconds(1), previousHash, data);
            
            Assert.True(hash1 == hash2);
            Assert.True(hash1 != hash3);
            Assert.True(hash1 != hash4 && hash3 != hash4);
            Assert.True(hash1 != hash5 && hash3 != hash5 && hash4 != hash5);
            Assert.True(hash1.Length == 64);
        }
    }
}