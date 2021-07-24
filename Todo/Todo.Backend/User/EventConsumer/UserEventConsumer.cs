﻿using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Contracts.Events.User;
using Todo.Database.Cosmos;

namespace Todo.Backend.User.EventConsumer
{
    public class UserEventConsumer : IConsumer<UserCreatedEvent>, IConsumer<UserDeletedEvent>, IConsumer<UserUpdatedEvent>
    {
        private readonly ILogger<UserEventConsumer> _logger;
        private readonly CosmosDbContext _cosmosDbContext;
        public UserEventConsumer(ILogger<UserEventConsumer> logger, CosmosDbContext cosmosDbContext)
        {
            _logger = logger;
            _cosmosDbContext = cosmosDbContext;
        }
        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            try
            {
                var @event = context.Message;
                var response = await _cosmosDbContext.CreateItemAsync(@event);
            }
            catch(Exception exception)
            {
                _logger.LogError(exception, "Failed to consume "+nameof(UserCreatedEvent));
            }
        }

        public Task Consume(ConsumeContext<UserDeletedEvent> context)
        {
            throw new System.NotImplementedException();
        }

        public Task Consume(ConsumeContext<UserUpdatedEvent> context)
        {
            throw new System.NotImplementedException();
        }
    }
}
