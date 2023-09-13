using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MessageService.Data;
using MessageService.Data.Models;
using MessageService.Data.Models.Enums;
using MessageService.Models;
using Microsoft.AspNetCore.Mvc;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageApplicationContext _context;

        public MessageController(MessageApplicationContext context)
        {
            _context = context;
        }

        [HttpPost("email")]
        public async Task SendEmail(
            [FromBody] SendEmailModel sendEmailModel,
            CancellationToken cancellationToken)
        {
            var newMessage = new Message
            {
                From = sendEmailModel.From,
                To = sendEmailModel.To,
                Text = sendEmailModel.Message,
                MessageType = (int)MessageType.Email
            };

            await _context.Messages.AddAsync(newMessage, cancellationToken);

            var addMessageEvent = new MessageEvent
            {
                Event = "AddEmailMessage",
                Data = JsonSerializer.Serialize(newMessage)
            };

            await _context.MessageEvents.AddAsync(addMessageEvent, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}