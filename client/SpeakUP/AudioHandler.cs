using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Net.Sockets;


namespace SpeakUP
{
    class AudioHandler
    {
        UdpClient _UDPclient = new UdpClient(6969);
        public bool isConnected = false; 

        public async Task<byte[]> ReceiveSound()
        {
            try
            {
                return (await _UDPclient.ReceiveAsync()).Buffer;
            }
            catch
            {
                return null;
            }
        }

        public async void SendSound()
        {

        }
        private async void PlaySound()
        {
            byte[] data;
            isConnected = true;
            WaveFormat waveFormat = new WaveFormat();
            BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(waveFormat);
            bufferedWaveProvider.DiscardOnBufferOverflow = true;

            WaveOut Player = new WaveOut();
            Player.Init(bufferedWaveProvider);
            Player.Play();

            while (isConnected)
            {
                data = await ReceiveSound();
                
                if (data != null)
                {
                    bufferedWaveProvider.AddSamples(data, 0, data.Length);
                }
            }
        }

        private void RecordSound()
        {

        }
    }
}
