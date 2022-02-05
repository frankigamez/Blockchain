using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Core
{
    public class Block
    {
        public string PreviousHash { get; }
        public DateTime TimeStamp { get; }
        public string Hash { get; }
        public string Data { get; }
        
        
        public Block(string previousHash, DateTime timeStamp, string hash, string data)
        {
            PreviousHash = previousHash;
            TimeStamp = timeStamp;
            Data = data;
            var computedHash = ComputeHash(timeStamp, previousHash, data);
            if (hash != computedHash) throw new Exception("Invalid Hash");
            Hash = hash;
        }
        
        public Block(string previousHash, DateTime timeStamp, string data)
        {
            PreviousHash = previousHash;
            TimeStamp = timeStamp;
            Data = data;
            Hash = ComputeHash(timeStamp, previousHash, data);
        }


        public Block Mine(string data, DateTime? timeStamp = null)
        {
            timeStamp ??= DateTime.UtcNow;
            return new Block(
                previousHash: this.Hash,
                timeStamp: timeStamp.Value,
                hash: ComputeHash(timeStamp.Value, this.Hash, data),
                data: data);
        }

        internal static string ComputeHash(DateTime timestamp, string previousHash, string data)
        {
            using var sha256 = SHA256.Create();
            return string.Join(string.Empty,
                sha256.ComputeHash(Encoding.UTF8.GetBytes($"{timestamp.Ticks}|{previousHash}|{data}"))
                    .Select(x => x.ToString("x2")));
        }
            

        public override string ToString() =>
            "Block " +
            $"  PreviousHash  : {PreviousHash}" +
            $"  Hash          : {Hash}" +
            $"  TimeStamp     : {TimeStamp}" +
            $"  Data          : {Data}";
    }
}