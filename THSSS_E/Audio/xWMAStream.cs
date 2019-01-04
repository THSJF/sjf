// Decompiled with JetBrains decompiler
// Type: Shooting.xWMAStream
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Multimedia;
using System;
using System.IO;
using System.Text;

namespace Shooting
{
  internal class xWMAStream : Stream
  {
    public const ushort WAVE_FORMAT_xWMA = 353;
    public const ushort WAVE_FORMAT_EXTENSIBLE = 65534;
    protected Stream dataStream;
    protected long dataOffset;
    protected int dataSize;
    protected int[] decodedPacketCumulativeBytes;
    protected WaveFormat format;

    public xWMAStream(Stream stream)
    {
      this.dataStream = stream;
      this.analyzeXWMAFileStream();
    }

    public xWMAStream(string path)
    {
      if (!File.Exists(path))
        throw new FileNotFoundException(path + " Not Found");
      this.dataStream = (Stream) new FileStream(path, FileMode.Open);
      this.analyzeXWMAFileStream();
    }

    private void analyzeXWMAFileStream()
    {
      byte[] numArray1 = new byte[4];
      this.dataStream.Seek(0L, SeekOrigin.Begin);
      this.dataStream.Read(numArray1, 0, 4);
      if (Encoding.ASCII.GetString(numArray1) != "RIFF")
        throw new InvalidDataException("Invalid xWMA file.");
      this.dataStream.Read(numArray1, 0, 4);
      if (this.dataStream.Length != (long) (BitConverter.ToInt32(numArray1, 0) + 8))
        throw new InvalidDataException("Invalid Format");
      this.dataStream.Read(numArray1, 0, 4);
      if (Encoding.ASCII.GetString(numArray1) != "XWMA")
        throw new InvalidDataException("Invalid xWMA file.");
      for (long index1 = (long) this.dataStream.Read(numArray1, 0, 4); index1 > 3L; index1 = (long) this.dataStream.Read(numArray1, 0, 4))
      {
        string str = Encoding.ASCII.GetString(numArray1);
        this.dataStream.Read(numArray1, 0, 4);
        int int32 = BitConverter.ToInt32(numArray1, 0);
        switch (str)
        {
          case "fmt ":
            this.dataStream.Read(numArray1, 0, 2);
            ushort uint16 = BitConverter.ToUInt16(numArray1, 0);
            this.format = new WaveFormat();
            this.dataStream.Read(numArray1, 0, 2);
            this.format.Channels = (short) BitConverter.ToUInt16(numArray1, 0);
            this.dataStream.Read(numArray1, 0, 4);
            this.format.SamplesPerSecond = BitConverter.ToInt32(numArray1, 0);
            this.dataStream.Read(numArray1, 0, 4);
            this.format.AverageBytesPerSecond = BitConverter.ToInt32(numArray1, 0);
            this.dataStream.Read(numArray1, 0, 2);
            this.format.BlockAlignment = BitConverter.ToInt16(numArray1, 0);
            this.dataStream.Read(numArray1, 0, 2);
            this.format.BitsPerSample = BitConverter.ToInt16(numArray1, 0);
            if (uint16 == (ushort) 353)
            {
              this.dataStream.Seek((long) (int32 - 16), SeekOrigin.Current);
              this.format.FormatTag = WaveFormatTag.WMAudio2;
              break;
            }
            if (uint16 != (ushort) 65534)
              throw new InvalidDataException("Invalid xWMA file.");
            WaveFormatExtensible formatExtensible = new WaveFormatExtensible();
            formatExtensible.Channels = this.format.Channels;
            formatExtensible.SamplesPerSecond = this.format.SamplesPerSecond;
            formatExtensible.AverageBytesPerSecond = this.format.AverageBytesPerSecond;
            formatExtensible.BlockAlignment = this.format.BlockAlignment;
            formatExtensible.BitsPerSample = this.format.BitsPerSample;
            this.dataStream.Read(numArray1, 0, 2);
            if (BitConverter.ToInt16(numArray1, 0) != (short) 22)
              throw new InvalidDataException("Invalid Format.");
            this.dataStream.Read(numArray1, 0, 2);
            formatExtensible.ValidBitsPerSample = BitConverter.ToInt16(numArray1, 0);
            this.dataStream.Read(numArray1, 0, 4);
            formatExtensible.ChannelMask = (Speakers) BitConverter.ToUInt32(numArray1, 0);
            byte[] numArray2 = new byte[16];
            this.dataStream.Read(numArray2, 0, 16);
            formatExtensible.SubFormat = new Guid(numArray2);
            formatExtensible.FormatTag = WaveFormatTag.Extensible;
            this.format = (WaveFormat) formatExtensible;
            break;
          case "dpds":
            if (int32 % 4 != 0)
              throw new InvalidDataException("Invalid Format.");
            int length = int32 / 4;
            this.decodedPacketCumulativeBytes = new int[length];
            for (int index2 = 0; index2 < length; ++index2)
            {
              this.dataStream.Read(numArray1, 0, 4);
              this.decodedPacketCumulativeBytes[index2] = BitConverter.ToInt32(numArray1, 0);
            }
            break;
          case "data":
            this.dataOffset = this.dataStream.Position;
            this.dataSize = int32;
            this.dataStream.Seek((long) int32, SeekOrigin.Current);
            break;
          default:
            this.dataStream.Seek((long) int32, SeekOrigin.Current);
            break;
        }
      }
      this.dataStream.Seek(this.dataOffset, SeekOrigin.Begin);
    }

    public int[] DecodedPacketCumulativeBytes
    {
      get
      {
        return this.decodedPacketCumulativeBytes;
      }
    }

    public WaveFormat Format
    {
      get
      {
        return this.format;
      }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      return this.dataStream.Read(buffer, offset, count);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      throw new NotSupportedException("xWMA Stream objects cannot be written to.");
    }

    public override void SetLength(long value)
    {
      throw new NotSupportedException("xWMA Stream objects cannot be resized.");
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      long offset1 = 0;
      switch (origin)
      {
        case SeekOrigin.Begin:
          offset1 = this.dataOffset + offset;
          break;
        case SeekOrigin.Current:
          offset1 = offset;
          break;
        case SeekOrigin.End:
          offset1 = this.dataOffset;
          break;
      }
      return this.dataStream.Seek(offset1, origin) - this.dataOffset;
    }

    public override void Flush()
    {
      throw new NotSupportedException("xWMA Stream objects cannot be flushed.");
    }

    public override int ReadByte()
    {
      if (this.dataStream.Position > this.dataOffset + (long) this.dataSize)
        return -1;
      return this.dataStream.ReadByte();
    }

    public override void WriteByte(byte value)
    {
      throw new NotSupportedException("xWMA Stream objects cannot be written to.");
    }

    public override void Close()
    {
      this.dataStream.Close();
    }

    protected override void Dispose(bool disposing)
    {
      this.dataStream.Dispose();
    }

    public override bool CanRead
    {
      get
      {
        return true;
      }
    }

    public override bool CanWrite
    {
      get
      {
        return false;
      }
    }

    public override bool CanSeek
    {
      get
      {
        return true;
      }
    }

    public override long Position
    {
      get
      {
        return this.dataStream.Position - this.dataOffset;
      }
      set
      {
        this.Seek(value, SeekOrigin.Begin);
      }
    }

    public override long Length
    {
      get
      {
        return (long) this.dataSize;
      }
    }
  }
}
