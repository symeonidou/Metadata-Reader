using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Png
    {
        private readonly List<Chunk> _chunkInfo = new();
        private readonly byte[] _metaData;

        public Png(byte[] metaData)
        {
            _metaData = metaData;

            ChunkAdd();
        }

        private int Width => (_metaData[16] << 24) + (_metaData[17] << 16) + (_metaData[18] << 8) + _metaData[19];
        private int Height => (_metaData[20] << 24) + (_metaData[21] << 16) + (_metaData[22] << 8) + _metaData[23];


        private void ChunkAdd()
        {
            var startIndex = 8;
            var chunkSize = 0;
            const int chunkInfoSize = 12;
            while (startIndex < _metaData.Length)
            {
                if (startIndex + 8 <= _metaData.Length)
                {
                    var sizeSection = new ArraySegment<byte>(_metaData, startIndex, 4);
                    chunkSize = chunkInfoSize + (sizeSection[0] << 24) + (sizeSection[1] << 16) + (sizeSection[2] << 8) + sizeSection[3];
                    var typeSegment = new ArraySegment<byte>(_metaData, startIndex + 4, 4);
                    var chunkType = Encoding.ASCII.GetString(typeSegment);
                    _chunkInfo.Add(new Chunk(chunkSize, chunkType));
                }
                startIndex += chunkSize;
            }
        }

        public IEnumerable<Chunk> GetListOfChunks()
        {
            return _chunkInfo;
        }

        public override string ToString()
        {
            return $"The format of this file is .png. \nThe resolution: {Width}x{Height} pixels.";
        }
    }
}