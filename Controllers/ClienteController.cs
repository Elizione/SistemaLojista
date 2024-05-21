using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_de_lojista.Models;
using Sistema_de_lojista.Services;
using X.PagedList;

namespace Sistema_de_lojista.Controllers
{
    public class ClienteController : Controller
    {
        private readonly Sistema_de_lojistaContext _context;
        int pageSize = 20;

        public ClienteController(Sistema_de_lojistaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string nomeRazaoSocial, string email, string telefone, DateTime? dataCadastro, string clienteBloqueado, int? page)
        {
            var clientes = _context.Clientes.AsQueryable();

            if (!String.IsNullOrEmpty(nomeRazaoSocial))
            {
                clientes = clientes.Where(c => c.NomeRazaoSocial.Contains(nomeRazaoSocial));
            }

            if (!String.IsNullOrEmpty(email))
            {
                clientes = clientes.Where(c => c.Email.Contains(email));
            }

            if (!String.IsNullOrEmpty(telefone))
            {
                clientes = clientes.Where(c => c.Telefone.Contains(telefone));
            }

            if (dataCadastro.HasValue)
            {
                clientes = clientes.Where(c => c.DataCadastro.Date == dataCadastro.Value.Date);
            }

            if (!String.IsNullOrEmpty(clienteBloqueado))
            {
                bool isBlocked = clienteBloqueado.ToUpper() == "SIM";
                clientes = clientes.Where(c => c.Bloqueado == isBlocked);
            }

            int pageNumber = (page ?? 1);

            return View(await clientes.ToPagedListAsync(pageNumber, pageSize));
        }

        public IActionResult ClearFilter()
        {
            var clientes = _context.Clientes.ToPagedList(1, pageSize); 

            return PartialView("_ClientesTable", clientes);
        }


        //// GET: Cliente
        //public async Task<IActionResult> Index()
        //{
        //    return _context.Clientes != null ?
        //                View(await _context.Clientes.ToListAsync()) :
        //                Problem("Entity set 'Sistema_de_lojistaContext.Cliente'  is null.");
        //}

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeRazaoSocial,Email,Telefone,DataCadastro,TipoPessoa,CPFCNPJ,InscricaoEstadual,Isento,Genero,DataNascimento,Bloqueado,Senha,ConfirmacaoSenha")] Cliente cliente)
        {
            //if (cliente.Senha != cliente.ConfirmacaoSenha)
            //{
            //    ModelState.AddModelError("ConfirmacaoSenha", "A confirmação de senha não corresponde à senha.");
            //    return View(cliente);
            //}

            if (ModelState.IsValid)
            {
                cliente.DataCadastro = DateTime.Now;
                cliente.CPFCNPJ = MaskManager.RemoverMascara(cliente.CPFCNPJ);
                cliente.InscricaoEstadual = MaskManager.RemoverMascara(cliente.InscricaoEstadual);
                cliente.Telefone = MaskManager.RemoverMascara(cliente.Telefone);

                try
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cliente criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    string msg = string.Empty;

                    if (e.InnerException.Message.Contains("clientes.Email"))
                    {
                        msg = "Este e-mail já está cadastrado para outro Cliente";
                    }

                    if (e.InnerException.Message.Contains("clientes.CPFCNPJ"))
                    {
                        msg = "Este CPF/ CNPJ já está cadastrado para outro Cliente";
                    }

                    if (e.InnerException.Message.Contains("clientes.InscricaoEstadual"))
                    {
                        msg = "Esta Inscrição Estadual já está cadastrada para outro Cliente";
                    }

                    TempData["ErrorMessage"] = msg;
                    return View(cliente);
                }

            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeRazaoSocial,Email,Telefone,DataCadastro,TipoPessoa,CPFCNPJ,InscricaoEstadual,Isento,Genero,DataNascimento,Bloqueado,Senha,ConfirmacaoSenha")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            //if (cliente.Senha != cliente.ConfirmacaoSenha)
            //{
            //    ModelState.AddModelError("ConfirmacaoSenha", "A confirmação de senha não corresponde à senha.");
            //    return View(cliente);
            //}

            if (ModelState.IsValid)
            {

                cliente.CPFCNPJ = MaskManager.RemoverMascara(cliente.CPFCNPJ);
                cliente.InscricaoEstadual = MaskManager.RemoverMascara(cliente.InscricaoEstadual);
                cliente.Telefone = MaskManager.RemoverMascara(cliente.Telefone);

                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'Sistema_de_lojistaContext.Cliente'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
