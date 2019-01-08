using SlimDX.Multimedia;
using System;
using System.IO;
using System.Text;

namespace Shooting {
    internal class xWMAStream:Stream {
        public const ushort WAVE_FORMAT_xWMA = 353;
        public const ushort WAVE_FORMAT_EXTENSIBLE = 65534;
        protected Stream dataStream;
        protected long dataOffset;
        protected int dataSize;
        protected int[] decodedPacketCumulativeBytes;
        protected WaveFormat format;
        public xWMAStream(Stream stream) {
            dataStream=stream;
            analyzeXWMAFileStream();
        }
        public xWMAStream(string path) {
            if(!File.Exists(path)) throw new FileNotFoundException(path+" Not Found");
            dataStream=new FileStream(path,FileMode.Open);
            analyzeXWMAFileStream();
        }
        private void analyzeXWMAFileStream() {
            byte[] numArray1 = new byte[4];
            dataStream.Seek(0L,SeekOrigin.Begin);
            dataStream.Read(numArray1,0,4);
            if(Encoding.ASCII.GetString(numArray1)!="RIFF") throw new InvalidDataException("Invalid xWMA file.");
            dataStream.Read(numArray1,0,4);
            if(dataStream.Length!=BitConverter.ToInt32(numArray1,0)+8) throw new InvalidDataException("Invalid Format");
            dataStream.Read(numArray1,0,4);
            if(Encoding.ASCII.GetString(numArray1)!="XWMA") throw new InvalidDataException("Invalid xWMA file.");
            for(long index1 = dataStream.Read(numArray1,0,4);index1>3L;index1=dataStream.Read(numArray1,0,4)) {
                string str = Encoding.ASCII.GetString(numArray1);
                dataStream.Read(numArray1,0,4);
                int int32 = BitConverter.ToInt32(numArray1,0);
                switch(str) {
                    case "fmt ":
                        dataStream.Read(numArray1,0,2);
                        ushort uint16 = BitConverter.ToUInt16(numArray1,0);
                        format=new WaveFormat();
                        dataStream.Read(numArray1,0,2);
                        format.Channels=(short)BitConverter.ToUInt16(numArray1,0);
                        dataStream.Read(numArray1,0,4);
                        format.SamplesPerSecond=BitConverter.ToInt32(numArray1,0);
                        dataStream.Read(numArray1,0,4);
                        format.AverageBytesPerSecond=BitConverter.ToInt32(numArray1,0);
                        dataStream.Read(numArray1,0,2);
                        format.BlockAlignment=BitConverter.ToInt16(numArray1,0);
                        dataStream.Read(numArray1,0,2);
                        format.BitsPerSample=BitConverter.ToInt16(numArray1,0);
                        if(uint16==353) {
                            dataStream.Seek(int32-16,SeekOrigin.Current);
                            format.FormatTag=WaveFormatTag.WMAudio2;
                            break;
                        }
                        if(uint16!=65534) throw new InvalidDataException("Invalid xWMA file.");
                        WaveFormatExtensible formatExtensible = new WaveFormatExtensible {
                            Channels=format.Channels,
                            SamplesPerSecond=format.SamplesPerSecond,
                            AverageBytesPerSecond=format.AverageBytesPerSecond,
                            BlockAlignment=format.BlockAlignment,
                            BitsPerSample=format.BitsPerSample
                        };
                        dataStream.Read(numArray1,0,2);
                        if(BitConverter.ToInt16(numArray1,0)!=22) throw new InvalidDataException("Invalid Format.");
                        dataStream.Read(numArray1,0,2);
                        formatExtensible.ValidBitsPerSample=BitConverter.ToInt16(numArray1,0);
                        dataStream.Read(numArray1,0,4);
                        formatExtensible.ChannelMask=(Speakers)BitConverter.ToUInt32(numArray1,0);
                        byte[] numArray2 = new byte[16];
                        dataStream.Read(numArray2,0,16);
                        formatExtensible.SubFormat=new Guid(numArray2);
                        formatExtensible.FormatTag=WaveFormatTag.Extensible;
                        format=formatExtensible;
                        break;
                    case "dpds":
                        if(int32%4!=0) throw new InvalidDataException("Invalid Format.");
                        int length = int32/4;
                        decodedPacketCumulativeBytes=new int[length];
                        for(int index2 = 0;index2<length;++index2) {
                            dataStream.Read(numArray1,0,4);
                            decodedPacketCumulativeBytes[index2]=BitConverter.ToInt32(numArray1,0);
                        }
                        break;
                    case "data":
                        dataOffset=dataStream.Position;
                        dataSize=int32;
                        dataStream.Seek(int32,SeekOrigin.Current);
                        break;
                    default:
                        dataStream.Seek(int32,SeekOrigin.Current);
                        break;
                }
            }
            dataStream.Seek(dataOffset,SeekOrigin.Begin);
        }
        public int[] DecodedPacketCumulativeBytes => decodedPacketCumulativeBytes;
        public WaveFormat Format => format;
        public override int Read(byte[] buffer,int offset,int count) => dataStream.Read(buffer,offset,count);
        public override void Write(byte[] buffer,int offset,int count) => throw new NotSupportedException("xWMA Stream objects cannot be written to.");
        public override void SetLength(long value) => throw new NotSupportedException("xWMA Stream objects cannot be resized.");
        public override long Seek(long offset,SeekOrigin origin) {
            long offset1 = 0;
            switch(origin) {
                case SeekOrigin.Begin:
                    offset1=dataOffset+offset;
                    break;
                case SeekOrigin.Current:
                    offset1=offset;
                    break;
                case SeekOrigin.End:
                    offset1=dataOffset;
                    break;
            }
            return dataStream.Seek(offset1,origin)-dataOffset;
        }
        public override void Flush() => throw new NotSupportedException("xWMA Stream objects cannot be flushed.");
        public override int ReadByte() {
            if(dataStream.Position>dataOffset+dataSize) return -1;
            return dataStream.ReadByte();
        }
        public override void WriteByte(byte value) => throw new NotSupportedException("xWMA Stream objects cannot be written to.");
        public override void Close() => dataStream.Close();
        protected override void Dispose(bool disposing) => dataStream.Dispose();
        public override bool CanRead => true;
        public override bool CanWrite => false;
        public override bool CanSeek => true;
        public override long Position {
            get => dataStream.Position-dataOffset;
            set => Seek(value,SeekOrigin.Begin);
        }
        public override long Length => dataSize;
    }
}
