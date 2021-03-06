﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contexto;
using DAL.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCloud.Models;
using Dispositivo = DAL.Entidades.Dispositivo;

namespace ProjetoCloud.Controllers
{
    [Authorize]
    public class DispositivosController : Controller
    {
        private readonly CloudContexto _context;

        public DispositivosController(CloudContexto context)
        {
            _context = context;
        }

        // GET: Dispositivos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dispositivos.ToListAsync());
        }

        // GET: Dispositivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivos
                .FirstOrDefaultAsync(m => m.Id_Dispositivo == id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        // GET: Dispositivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dispositivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string nome_ambiente, [Bind("Id_Dispositivo,Nome_Dispositivo,Status_Dispositivo")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                Ambiente ambiente = _context.Ambientes.Where(_ => _.Nome_Ambiente.Equals(nome_ambiente)).FirstOrDefault();

                if (ambiente == null)
                {
                    ambiente = new Ambiente();
                    ambiente.Nome_Ambiente = nome_ambiente;
                    ambiente.Qtda_Dispositivo_Ambiente = 0;
                    ambiente.Data_Cadastro_Ambiente = DateTime.UtcNow;
                    _context.Add(ambiente);
                    _context.SaveChanges();
                }

                //Cadastrando Dispositivo.
                dispositivo.Data_Cadastro_Dispositivo = DateTime.Now;
                dispositivo.Ambiente = ambiente;
                _context.Add(dispositivo);
                await _context.SaveChangesAsync();

                if (ambiente != null)
                {
                    //Atualizando quantidade dispositivos no ambiente.
                    ambiente.Qtda_Dispositivo_Ambiente++;
                    ambiente.Dispositivos_Ambiente.Add(dispositivo);
                    _context.Update(ambiente);
                    _context.SaveChanges();

                }

                return RedirectToAction(nameof(Index));
            }
            return View(dispositivo);
        }

        // GET: Dispositivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivos.FindAsync(id);
            if (dispositivo == null)
            {
                return NotFound();
            }
            return View(dispositivo);
        }

        // POST: Dispositivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Dispositivo,Nome_Dispositivo,Status_Dispositivo")] Dispositivo dispositivo)
        {
            if (id != dispositivo.Id_Dispositivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dispositivo.Data_Cadastro_Dispositivo = DateTime.Now;
                    _context.Update(dispositivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DispositivoExists(dispositivo.Id_Dispositivo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dispositivo);
        }

        // GET: Dispositivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispositivo = await _context.Dispositivos
                .FirstOrDefaultAsync(m => m.Id_Dispositivo == id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            return View(dispositivo);
        }

        // POST: Dispositivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Dispositivo dispositivo = _context.Dispositivos.Where(_ => _.Id_Dispositivo == id).Include(_ => _.Ambiente).FirstOrDefault();

            Ambiente ambiente = dispositivo.Ambiente;

            if (ambiente != null)
            {
                // Remove a Quantidade de dispositivos no ambiente.
                ambiente.Qtda_Dispositivo_Ambiente--;
                _context.Ambientes.Update(ambiente);
                _context.SaveChanges();
            }

            // Remove dispositivo.
            _context.Dispositivos.Remove(dispositivo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool DispositivoExists(int id)
        {
            return _context.Dispositivos.Any(e => e.Id_Dispositivo == id);
        }
    }
}
