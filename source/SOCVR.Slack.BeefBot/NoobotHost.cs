﻿using Noobot.Core;
using Noobot.Core.Configuration;
using Noobot.Core.DependencyResolution;
using Noobot.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOCVR.Slack.BeefBot
{
    public class NoobotHost : INoobotHost
    {
        private readonly IConfigReader _configReader;
        private INoobotCore _noobotCore;
        private readonly Custom.Configuration _configuration;

        public NoobotHost(IConfigReader configReader)
        {
            _configReader = configReader;
            _configuration = new Custom.Configuration();
        }

        public void Start()
        {
            IContainerFactory containerFactory = new ContainerFactory(_configuration, _configReader, new ConsoleLog());
            INoobotContainer container = containerFactory.CreateContainer();
            _noobotCore = container.GetNoobotCore();

            Console.WriteLine("Connecting...");
            _noobotCore
                .Connect()
                .ContinueWith(task =>
                {
                    if (!task.IsCompleted || task.IsFaulted)
                    {
                        Console.WriteLine($"Error connecting to Slack: {task.Exception}");
                    }
                });
        }

        public void Stop()
        {
            Console.WriteLine("Disconnecting...");
            _noobotCore.Disconnect();
        }
    }
}
