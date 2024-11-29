﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Models;
using Server.Models.DTO;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly Context _context;

        public ChatsController(Context context)
        {
            _context = context;
        }

        // GET: api/Chats
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Chat>>> GetChats()
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            var chats = await _context.Chats
        .Include(c => c.User) // Cargar la relación del usuario
        .Select(c => new ChatDTO
        {
            Id = c.Id,
            IdUsuario = c.IdUsuario,
            Mensaje = c.Mensaje,
            Rol = c.Rol,
            Fecha = c.Fecha.HasValue
            ? TimeZoneInfo.ConvertTimeFromUtc(c.Fecha.Value, timeZone)
            : (DateTime?)null,
            ConversacionId = c.ConversacionId,
            NombreCompleto = c.User != null ? $"{c.User.Name} {c.User.LastName}" : null,
            Email = c.User.Email
        })
        .ToListAsync();

            return Ok(chats);
        }

        // GET: api/Chats/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Chat>> GetChat(int? id)
        {
            var chat = await _context.Chats.FindAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            return chat;
        }

        // PUT: api/Chats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // PUT: api/Chats/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutChat(int? id, ChatDTO chatDTO)
        {
            if (id != chatDTO.Id)
            {
                return BadRequest();
            }

            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            // Map properties from ChatDTO to Chat entity
            chat.IdUsuario = chatDTO.IdUsuario;
            chat.Mensaje = chatDTO.Mensaje;
            chat.Rol = chatDTO.Rol;
            chat.Fecha = chatDTO.Fecha;
            chat.ConversacionId = chatDTO.ConversacionId;

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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

        // POST: api/Chats
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<Chat>> PostChat(ChatDTO chatDTO)
        {
            // Map ChatDTO to Chat entity
            var chat = new Chat
            {
                IdUsuario = chatDTO.IdUsuario,
                Mensaje = chatDTO.Mensaje,
                Rol = chatDTO.Rol,
                Fecha = chatDTO.Fecha,
                ConversacionId = chatDTO.ConversacionId
            };

            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChat", new { id = chat.Id }, chat);
        }


        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteChat(int? id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatExists(int? id)
        {
            return _context.Chats.Any(e => e.Id == id);
        }
    }
}
