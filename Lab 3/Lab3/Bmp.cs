namespace Lab3
{
    public class Bmp
    {
        private readonly byte[] _metaData;

        public Bmp(byte[] metaData)
        {
            _metaData = metaData;
        }

        private int Width
        {
            get
            {
                return _metaData[18] + (_metaData[19] << 8) + (_metaData[20] << 16) + (_metaData[21] << 24);
            }
        }

        private int Height
        {
            get
            {
                return _metaData[22] + (_metaData[23] << 8) + (_metaData[24] << 16) + (_metaData[25] << 24);
            }
        }

        public override string ToString()
        {
            return $"The format of this file is .bmp. \nResolution: {Width}x{Height} pixels.";
        }
    }
}