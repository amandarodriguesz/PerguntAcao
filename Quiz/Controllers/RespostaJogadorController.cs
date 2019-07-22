using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;

namespace Quiz.Controllers
{
    public class RespostaJogadorController : Controller
    {
        private readonly QuizContext _context;

        public RespostaJogadorController(QuizContext context)
        {
            _context = context;
        }

        // GET: RespostaJogador
        public async Task<IActionResult> Index()
        {
            var quizContext = _context.RespostaJogador.Include(r => r.Jogador).Include(r => r.Questao);
            return View(await quizContext.ToListAsync());
        }

        // GET: RespostaJogador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaJogador = await _context.RespostaJogador
                .Include(r => r.Jogador)
                .Include(r => r.Questao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respostaJogador == null)
            {
                return NotFound();
            }

            return View(respostaJogador);
        }

        // GET: RespostaJogador/Create
        public IActionResult Create()
        {
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "Id", "Id");
            ViewData["QuestaoId"] = new SelectList(_context.Questao, "Id", "Id");
            return View();
        }

        // POST: RespostaJogador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JogadorId,QuestaoId,Resposta")] RespostaJogador respostaJogador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respostaJogador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "Id", "Id", respostaJogador.JogadorId);
            ViewData["QuestaoId"] = new SelectList(_context.Questao, "Id", "Id", respostaJogador.QuestaoId);
            return View(respostaJogador);
        }

        // GET: RespostaJogador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaJogador = await _context.RespostaJogador.FindAsync(id);
            if (respostaJogador == null)
            {
                return NotFound();
            }
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "Id", "Id", respostaJogador.JogadorId);
            ViewData["QuestaoId"] = new SelectList(_context.Questao, "Id", "Id", respostaJogador.QuestaoId);
            return View(respostaJogador);
        }

        // POST: RespostaJogador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JogadorId,QuestaoId,Resposta")] RespostaJogador respostaJogador)
        {
            if (id != respostaJogador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respostaJogador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespostaJogadorExists(respostaJogador.Id))
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
            ViewData["JogadorId"] = new SelectList(_context.Jogador, "Id", "Id", respostaJogador.JogadorId);
            ViewData["QuestaoId"] = new SelectList(_context.Questao, "Id", "Id", respostaJogador.QuestaoId);
            return View(respostaJogador);
        }

        // GET: RespostaJogador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostaJogador = await _context.RespostaJogador
                .Include(r => r.Jogador)
                .Include(r => r.Questao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (respostaJogador == null)
            {
                return NotFound();
            }

            return View(respostaJogador);
        }

        // POST: RespostaJogador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respostaJogador = await _context.RespostaJogador.FindAsync(id);
            _context.RespostaJogador.Remove(respostaJogador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespostaJogadorExists(int id)
        {
            return _context.RespostaJogador.Any(e => e.Id == id);
        }
    }
}
