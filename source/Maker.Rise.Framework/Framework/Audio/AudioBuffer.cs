using OpenTK.Audio.OpenAL;
using System;

namespace Maker.Rise.Framework.Audio
{
    public sealed class AudioBuffer
    {
        public int Handle { get; private set; } = -1;
        public int Channels { get; private set; } = -1;
        public int BitsPerSample { get; private set; } = -1;
        public int SampleRate { get; private set; } = -1;

        public AudioBuffer(int bufferHandle, int channels, int bitsPerSample, int sampleRate)
        {
            Handle = bufferHandle;
            Channels = channels;
            BitsPerSample = bitsPerSample;
            SampleRate = sampleRate;
        }

        public ALFormat GetSoundFormat()
        {
            switch (Channels)
            {
                case 1: return BitsPerSample == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
                case 2: return BitsPerSample == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
                default: throw new NotSupportedException("The specified sound format is not supported.");
            }
        }

        public AudioSource CreateAudioSource()
        {
            return new AudioSource(this);
        }

        public void Destroy()
        {
            AL.DeleteBuffer(Handle);
        }
    }
}
