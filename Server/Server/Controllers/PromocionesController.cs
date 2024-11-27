﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Models;
using Server.Models.DTO;
using Newtonsoft.Json;

namespace Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PromocionesController : ControllerBase
	{
		private readonly Context _context;
		public PromocionesController(Context context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("Promos")]
		public async Task<IActionResult> GetPromos()
		{
			try
			{
				var promos = await _context.Promociones.ToListAsync();

				if (promos == null || promos.Count == 0)
				{
					return BadRequest("No hay promos registradas");
				}

				return Ok(promos);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("vale kk");
			}
		}

		[HttpGet]
		[Route("allPromociones/{IdBadge}")]
		public async Task<IActionResult> GetAllPromociones(int IdBadge)
		{
			try
			{
				var promos = await _context.Promociones.Where(p => p.Estado == 1).Where(p => p.BadgePromoId == IdBadge).ToListAsync();

				if (promos == null || promos.Count == 0)
				{
					return BadRequest("No hay promos registradas");
				}

				return Ok(promos);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("vale kk");
			}
		}

		[HttpPost]
		[Route("addPromocion")]
		public async Task<IActionResult> AddPromocion([FromBody] PromocionesDTO data)
		{
			try
			{
				if (data == null)
				{
					return BadRequest("No se recibieron datos");
				}

				// Validar que data contenga todos los campos necesarios
				if (data.Nombre == null || data.Descripcion == null || data.FechaInicio == null || data.FechaFin == null || data.Descuento == 0 || data.Estado == 0 || data.Productos == 0 || data.LimiteCanje == 0)
				{
					return BadRequest("Faltan campos por llenar");
				}

				var usuario = await _context.Users.FindAsync(data.UserId);

				if (usuario == null)
				{
					return BadRequest("No se encontro el usuario");
				}

				// Transforma la cantidad del descuento a un porcentaje
				var desc = data.Descuento / 100;

				// obtener el producto
				var producto = await _context.Productos.FindAsync(data.Productos);

				var nuevoPrecio = producto.Precio - (producto.Precio * desc);

				var promocion = new Promociones
				{
					Nombre = data.Nombre,
					Descripcion = data.Descripcion,
					FechaInicio = data.FechaInicio,
					FechaFin = data.FechaFin,
					Productos = data.Productos,
					Descuento = (decimal)nuevoPrecio,
					Estado = data.Estado,
					BadgePromoId = data.BadgePromoId,
					LimiteCanje = data.LimiteCanje,
					CreatedAt = DateTime.Now.ToString(),
					UpdatedAt = DateTime.Now.ToString(),
					DeletedAt = ""
				};

				await _context.Promociones.AddAsync(promocion);

				await _context.SaveChangesAsync();

				return Ok(200);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return NotFound("Se produjo un error en el servidor, contacte a soporte");
			}
		}

		[HttpPut]
		[Route("updatePromocion/{id}")]
		public async Task<IActionResult> UpdatePromocion(int id, [FromBody] PromocionesDTO data)
		{
			try
			{
				var promocion = await _context.Promociones.FindAsync(id);

				if (promocion == null)
				{
					return BadRequest("No se encontro la promocion");
				}

				promocion.Nombre = data.Nombre;
				promocion.Descripcion = data.Descripcion;
				promocion.Descuento = data.Descuento;
				promocion.Estado = data.Estado;
				promocion.LimiteCanje = data.LimiteCanje;
				promocion.UpdatedAt = DateTime.Now.ToString();
				promocion.FechaInicio = data.FechaInicio;
				promocion.FechaFin = data.FechaFin;
				promocion.Productos = data.Productos;
				if (data.BadgePromoId != 0)
				{
					promocion.BadgePromoId = data.BadgePromoId;
				}

				await _context.SaveChangesAsync();

				return Ok(200);
			}
			catch (Exception ex)
			{
				//Console.WriteLine(ex.Message);
				return NotFound("Se produjo un error en el servidor, contacte a soporte");
			}
		}

		[HttpPut]
		[Route("deletePromocion/{id}")]
		public async Task<IActionResult> DeletePromocion(int id)
		{
			try
			{
				var promocion = await _context.Promociones.FindAsync(id);

				if (promocion == null)
				{
					return BadRequest("No se encontro la promocion");
				}

				promocion.DeletedAt = DateTime.Now.ToString();
				promocion.Estado = 0;

				await _context.SaveChangesAsync();

				return Ok(200);
			}
			catch (Exception ex)
			{
				//Console.WriteLine(ex.Message);
				return NotFound("Se produjo un error en el servidor, contacte a soporte");
			}
		}

		[HttpDelete]
		[Route("hardDeletePromocion/{id},{userId}")]
		public async Task<IActionResult> HardDeletePromocion(int id, int userId)
		{
			try
			{
				var promocion = await _context.Promociones.FindAsync(id);

				if (promocion == null)
				{
					return BadRequest("No se encontro la promocion");
				}

				var usuario = await _context.Users.FindAsync(userId);

				if (usuario == null)
				{
					return BadRequest("No se encontro el usuario");
				}

				string connectionString;

				if (usuario.Role == "Admin")
				{
					connectionString = "AdminUser";
				}
				else
				{
					connectionString = "ClientUser";
				}

				var optionsBuilder = new DbContextOptionsBuilder<Context>();
				optionsBuilder.UseSqlServer(connectionString);

				using (var context = new Context(optionsBuilder.Options))
				{
					// Aquí puedes realizar operaciones con el contexto configurado
					_context.Promociones.Remove(promocion);

					await _context.SaveChangesAsync();
					return Ok($"Conectado como {usuario.Role} a la base de datos");
				}


				//return Ok(200);
			}
			catch (Exception ex)
			{
				//Console.WriteLine(ex.Message);
				return NotFound("Se produjo un error en el servidor, contacte a soporte");
			}
		}

		[HttpGet]
		[Route("getPromocion/{id}")]
		public async Task<IActionResult> GetPromocion(int id)
		{
			try
			{
				var promocion = await _context.Promociones.FindAsync(id);

				if (promocion == null)
				{
					return BadRequest("No se encontro la promocion");
				}
				else if (promocion.Estado == 0)
				{
					return BadRequest("La promoción fué eliminada");
				}

				return Ok(promocion);
			}
			catch (Exception ex)
			{
				//Console.WriteLine(ex.Message);
				return NotFound("Se produjo un error en el servidor, contacte a soporte");
			}
		}
	}
}
