﻿// ==============================================================================================================
// Microsoft patterns & practices
// CQRS Journey project
// ==============================================================================================================
// Copyright (c) Microsoft Corporation and contributors http://cqrsjourney.github.com/contributors/members
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance 
// with the License. You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software distributed under the License is 
// distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and limitations under the License.
// ==============================================================================================================

namespace Azure
{
    using System.Collections.Generic;
    using Azure.Messaging;
    using Common;

    /// <summary>
    /// A command bus that sends commands to a service bus queue.
    /// </summary>
    public class CommandBus : ICommandBus
    {
        private Sender sender;

        public CommandBus(BusSettings settings)
        {
            this.sender = new Sender(settings);
        }

        public void Send(Envelope<ICommand> command)
        {
            this.sender.Send(command);
        }

        public void Send(IEnumerable<Envelope<ICommand>> commands)
        {
            // TODO: batch/transactional sending?
            foreach (var command in commands)
            {
                this.Send(command);
            }
        }
    }
}
