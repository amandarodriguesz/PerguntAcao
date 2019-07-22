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
    public class QuestaoController : Controller
    {
        private readonly QuizContext _context;

        public QuestaoController(QuizContext context)
        {
            _context = context;
        }

        // GET: Questao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questao.ToListAsync());
        }

        // GET: Questao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questao == null)
            {
                return NotFound();
            }

            return View(questao);
        }

        // GET: Questao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pergunta,Opcao_a,Opcao_b,Opcao_c,Opcao_d,Resposta_certa")] Questao questao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questao);
        }

        // GET: Questao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questao.FindAsync(id);
            if (questao == null)
            {
                return NotFound();
            }
            return View(questao);
        }

        // POST: Questao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pergunta,Opcao_a,Opcao_b,Opcao_c,Opcao_d,Resposta_certa")] Questao questao)
        {
            if (id != questao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestaoExists(questao.Id))
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
            return View(questao);
        }

        // GET: Questao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questao == null)
            {
                return NotFound();
            }

            return View(questao);
        }

        // POST: Questao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questao = await _context.Questao.FindAsync(id);
            _context.Questao.Remove(questao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestaoExists(int id)
        {
            return _context.Questao.Any(e => e.Id == id);
        }
    }
}
