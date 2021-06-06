﻿using System;
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
        UdpClient _UDPclient = new UdpClient(6969);
        public bool isConnected = false;
        public List<string> OnCall = new List<string>();
        WaveInEvent waveSource = new WaveInEvent();
        WaveOut Player = new WaveOut();

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
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), 6969);
            while (data.Length != 0)
            {
               
                var tempData = data.Take(350).ToArray();
                data = data.Skip(350).ToArray();
                await _UDPclient.SendAsync(tempData, tempData.Length, ep);
            }
        }
        public async void PlaySound()
        {
            byte[] data;
            isConnected = true;
            WaveFormat waveFormat = new WaveFormat();
            BufferedWaveProvider bufferedWaveProvider = new BufferedWaveProvider(waveFormat);
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
           
           waveSource.WaveFormat = new WaveFormat();
           waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(WaveIn_DataAvailable);
           waveSource.StartRecording();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            foreach (string ip in OnCall) { Task.Run(() => SendSound(e.Buffer, ip)); }
                  
            
        }

        public void Disconnect()
        {
            waveSource.StopRecording();
            isConnected = false;
            Player.Stop();
        }

    }
}