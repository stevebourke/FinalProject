using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SurfProject.Model;

namespace SurfProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MemberDetailsContext _context;

        public MessagesController(MemberDetailsContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }


        // GET: api/Messages/5
        [HttpGet("{id}")]
        public IEnumerable<Message> GetMessage([FromRoute]int myID)
        {
            IEnumerable<Message> myMessages;

            //if (senderID == -1)
            
                myMessages = _context.Messages.Where(x => x.RecipientID == myID);
            

            //else
            //{
            //    myMessages = _context.Messages.Where(x => x.RecipientID == myID && x.SenderID == senderID);
            //}

            return myMessages;
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage([FromRoute] int id, [FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.MessageID)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Messages
        [HttpPost]
        public async Task<IActionResult> PostMessage([FromRoute] int messageID, int messageTime, int senderID,
            int recipientID, string messageBody)
        {

            //Create a new message from the incoming parameters...
            Message postMessage = new Message()
            {
                MessageID = messageID,

                MessageTime = messageTime,

                SenderID = senderID,

                RecipientID = recipientID,

                MessageBody = messageBody
            };



            //...and save to the database
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Messages.Add(postMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = postMessage.MessageID }, postMessage);
        }



        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return Ok(message);
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.MessageID == id);
        }
    }
}