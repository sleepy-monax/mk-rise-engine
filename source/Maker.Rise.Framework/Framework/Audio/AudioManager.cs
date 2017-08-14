using NAudio.Wave;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using System;
using System.Collections.Generic;

namespace Maker.Rise.Framework.Audio
{
    public enum AudioFormat { WAV, MP3 }

    public sealed class AudioManager : EngineComponent, IUpdateable
    {
        public bool Enable { get; set; }
        private Dictionary<string, AudioBuffer> ManagedAudioBuffer;
        private List<AudioSource> ManagedAudioSource;
        private AudioContext Context;

        public override void Load()
        {
            Context = new AudioContext();
            Context.MakeCurrent();
            
            Enable = true;
            ManagedAudioBuffer = new Dictionary<string, AudioBuffer>();
            ManagedAudioSource = new List<AudioSource>();
        }

        public override void Destroy()
        {
            Context.Dispose();
        }

        public void Update(float deltaTime)
        {
            ManagedAudioSource.RemoveAll(item => !item.IsPlaying());
        }

        public void PlaySoundEffect(string fileName, float volume = 1f, float pith = 1f, bool looping = false)
        {
            AudioSource source = CreateAudioSource(fileName);
            source.SetVolume(volume);
            source.SetPitch(pith);
            source.SetLooping(looping);
            source.Play();
        }

        public AudioSource CreateAudioSource(string fileName, bool managed = true)
        {
            var source = GetAudioBuffer(fileName).CreateAudioSource();

            if (managed) ManagedAudioSource.Add(source);
           
            return source;
        }

        public void StopAllManagedAudioSource()
        {
            foreach (AudioSource s in ManagedAudioSource)
            {
                s.Stop();
                s.Destroy();
                ManagedAudioSource.Remove(s);
            }
        }

        private AudioBuffer GetAudioBuffer(string fileName)
        {
            if (!ManagedAudioBuffer.ContainsKey(fileName))
            {
                WaveStream stream;
                if (fileName.ToLower().EndsWith(".mp3"))
                {
                    stream = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(fileName));
                }
                else if (fileName.ToLower().EndsWith(".wav"))
                {
                    stream = WaveFormatConversionStream.CreatePcmStream(new WaveFileReader(fileName));
                }
                else
                {
                    throw new Exception("Audio format not suported.");
                }


                // Load the sound to the buffer.
                int bufferHandle = AL.GenBuffer();
                byte[] soundData = new byte[stream.Length];
                stream.Read(soundData, 0, (int)stream.Length);
                AudioBuffer sound = new AudioBuffer(bufferHandle, stream.WaveFormat.Channels, stream.WaveFormat.BitsPerSample, stream.WaveFormat.SampleRate);

                AL.BufferData(sound.Handle, sound.GetSoundFormat(), soundData, soundData.Length, sound.SampleRate);
                ManagedAudioBuffer.Add(fileName, sound);
                stream.Dispose();
            }

            return ManagedAudioBuffer[fileName];
        }
    }
}
