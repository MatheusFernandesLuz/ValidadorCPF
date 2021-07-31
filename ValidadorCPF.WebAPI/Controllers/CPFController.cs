using Microsoft.AspNetCore.Mvc;
using ValidadorCPF.Dominio;
using System.Linq;
using ValidadorCPF.WebAPI.Exceptions;
using ValidadorCPF.Suporte;
using System;

namespace ValidadorCPF.WebAPI.Controllers
{
    [ApiController]
    [Route("cpf")]
    public class CPFController : ControllerBase
    {
        private readonly Repo.AppContext _context;

        public CPFController(Repo.AppContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult FindAll()
        {
            var resultado = _context.CPF.ToList();
            return Ok(resultado);
        }

        [HttpPost]
        public ActionResult Add(CPF dados)
        {
            try
            {
                dados.Cpf = CPFValidator.GetOnlyNumbers(dados.Cpf);

                if (!CPFValidator.IsValidCPF(dados.Cpf))
                {
                    throw new InvalidCpfException();
                }

                var existente = _context.CPF.FirstOrDefault(c => c.Cpf == dados.Cpf);

                if (existente != null)
                {
                    throw new ExistCpfExeption();
                }

                _context.Add(dados);
                _context.SaveChanges();

                return Created("/cpf", dados);
            }
            catch (Exception ex)
            {
                return BadRequest(new { type = ex.GetType().Name, message = ex.Message });
            }            
        }

        [HttpGet("{cpf}")]
        public ActionResult Check(string cpf)
        {
            try
            {
                if (!CPFValidator.IsValidCPF(cpf))
                {
                    throw new InvalidCpfException();
                }

                var resultado = _context.CPF.FirstOrDefault(c => c.Cpf == cpf);

                if (resultado == null)
                {
                    throw new NotFoundCpfException();
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { type = ex.GetType().Name, message = ex.Message });
            }
        } 

        [HttpDelete("{cpf}")]
        public ActionResult Delete(string cpf)
        {
            try
            {
                if (!CPFValidator.IsValidCPF(cpf))
                {
                    throw new InvalidCpfException();
                }

                var delete = _context.CPF.FirstOrDefault(c => c.Cpf == CPFValidator.GetOnlyNumbers(cpf));

                if (delete == null)
                {
                    throw new NotFoundCpfException();
                }

                _context.CPF.Remove(delete);
                _context.SaveChanges();

                return Ok(new { message = "cpf removed successfully" });
            }
            catch (Exception ex)
            {
                return NotFound(new { type = ex.GetType().Name, message = ex.Message });
            }
        }
    }
}
