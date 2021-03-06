﻿using SharpAdbClient.Logs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SharpAdbClient.Tests
{
    internal class DummyAdbClient : IAdbClient
    {
        public Dictionary<string, string> Commands
        { get; private set; } = new Dictionary<string, string>();

        public Collection<string> ReceivedCommands
        { get; private set; } = new Collection<string>();

        public EndPoint EndPoint
        { get; private set; }

        public void Connect(DnsEndPoint endpoint)
        {
            throw new NotImplementedException();
        }

        public void CreateForward(DeviceData device, ForwardSpec local, ForwardSpec remote, bool allowRebind)
        {
            throw new NotImplementedException();
        }

        public void CreateForward(DeviceData device, string local, string remote, bool allowRebind)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteRemoteCommandAsync(string command, DeviceData device, IShellOutputReceiver receiver, CancellationToken cancellationToken, int maxTimeToOutputResponse)
        {
            this.ReceivedCommands.Add(command);

            if (this.Commands.ContainsKey(command))
            {
                if (receiver != null)
                {
                    StringReader reader = new StringReader(this.Commands[command]);

                    while (reader.Peek() != -1)
                    {
                        receiver.AddOutput(reader.ReadLine());
                    }

                    receiver.Flush();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(command), $"The command '{command}' was unexpected");
            }

            return Task.FromResult(true);
        }

        public int GetAdbVersion()
        {
            throw new NotImplementedException();
        }

        public List<DeviceData> GetDevices()
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetFrameBufferAsync(DeviceData device, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Framebuffer CreateRefreshableFramebuffer(DeviceData device)
        {
            throw new NotImplementedException();
        }

        public void KillAdb()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ForwardData> ListForward(DeviceData device)
        {
            throw new NotImplementedException();
        }

        public void Reboot(string into, DeviceData device)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllForwards(DeviceData device)
        {
            throw new NotImplementedException();
        }

        public void RemoveForward(DeviceData device, int localPort)
        {
            throw new NotImplementedException();
        }

        public Task RunLogServiceAsync(DeviceData device, Action<LogEntry> sink, CancellationToken cancellationToken, params LogId[] logNames)
        {
            throw new NotImplementedException();
        }

        public void SetDevice(IAdbSocket socket, DeviceData device)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LogEntry> RunLogService(DeviceData device, CancellationToken cancellationToken, params LogId[] logNames)
        {
            throw new NotImplementedException();
        }
    }
}
