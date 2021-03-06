using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Net.Sockets;
using System.Net;

namespace SpeakUP
{
    class AudioHandler
    {
        public UdpClient _UDPclient = new UdpClient(54321);
        public bool isConnected = false;
        public List<string> OnCall = new List<string>();
        WaveInEvent waveSource = new WaveInEvent();
        WaveOut Player = new WaveOut();
       
        BufferedWaveProvider TestBuffer = new BufferedWaveProvider(new WaveFormat());
        BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat());

        public AudioHandler()
        {
            waveSource.DataAvailable += WaveIn_DataAvailable;
            waveSource.WaveFormat = new WaveFormat();
        }
        private async Task<byte[]> ReceiveSound()
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

        private async void SendSound(byte[] data, string ip)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), 54321);
            while (data.Length != 0 && OnCall.Count > 0)
            {
               
                var tempData = data.Take(1000).ToArray();
                data = data.Skip(1000).ToArray();
                await _UDPclient.SendAsync(tempData, tempData.Length, ep);
            }
        }
        public async void PlaySound()
        {
            byte[] data;
            isConnected = true;
            bufferedWaveProvider.DiscardOnBufferOverflow = true;

            
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

        
        public void RecordSound()
        {
           waveSource.StartRecording();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            foreach (string ip in OnCall) { Task.Run(() => SendSound(e.Buffer, ip)); }
            // TestBuffer.AddSamples(e.Buffer, 0, e.BytesRecorded)

        }

        public void Disconnect()
        {
            waveSource.StopRecording();
            isConnected = false;
            Player.Stop();
            bufferedWaveProvider.ClearBuffer();
            OnCall.Clear();
            //DLA GITHUBA :)
        }

        public void PlaySoundSelf() //for testing
        {
            isConnected = true;
            WaveFormat waveFormat = new WaveFormat();
            BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(waveFormat);
            bufferedWaveProvider.DiscardOnBufferOverflow = true;


            Player.Init(TestBuffer);
            Player.Play();
        }

        public void refreshPlayer()
        {
            if (isConnected)
            {
                Player.Stop();
                bufferedWaveProvider.ClearBuffer();
                Player.Play();
            }
        }
    }
}
