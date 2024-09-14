using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSWEBAPI.Data;
using SMSWEBAPI.Models;
using System;

namespace SMSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ChatController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet("GetMessages")]
        public IActionResult GetMessages(int senderId, int receiverId)
        {
            var messages = db.Chats
                .Where(c => (c.SenderId == senderId && c.ReceiverId == receiverId) ||
                            (c.SenderId == receiverId && c.ReceiverId == senderId))
                .OrderBy(c => c.Timestamp)
                .ToList();

            return Ok(messages);
        }

        // Send a new message
        [HttpPost("SendMessage")]
        public IActionResult SendMessage([FromBody] Chat chat)
        {
            chat.Timestamp = DateTime.Now;
            db.Chats.Add(chat);
            db.SaveChanges();
            return Ok(chat);
        }
    }
}

