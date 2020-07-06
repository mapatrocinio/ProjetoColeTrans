using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Data.Repository;
using Projeto.Services.Models.Cliente;

namespace Projeto.Services.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //atributo
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model)
        {
            //verificando se os campos da model passaram nas valida��es
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = mapper.Map<Cliente>(model);
                    clienteRepository.Inserir(cliente);

                    var result = new
                    {
                        message = "Cliente cadastrado com sucesso", 
                        	cliente
                    };

                    return Ok(result); //HTTP 200 (SUCESSO!)
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Erro: " + e.Message);
                }
            }
            else
            {
                //Erro HTTP 400 (BAD REQUEST)
                return BadRequest("Ocorreram erros de valida��o.");
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model)
        {
            //verificando se os campos da model passaram nas valida��es
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = mapper.Map<Cliente>(model);
                    clienteRepository.Alterar(cliente);

                    var result = new
                    {
                        message = "Cliente atualizado com sucesso",
                        	cliente
                    };

                    return Ok(result); //HTTP 200 (SUCESSO!)
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Erro: " + e.Message);
                }
            }
            else
            {
                //Erro HTTP 400 (BAD REQUEST)
                return BadRequest("Ocorreram erros de valida��o.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                //buscar o Cliente referente ao id informado..
                var cliente = clienteRepository.ObterPorId(id);

                //verificar se o Cliente foi encontrado..
                if (cliente != null)
                {
                    //excluindo o Cliente
                    clienteRepository.Excluir(cliente);

                    var result = new
                    {
                        message = "Cliente exclu�do com sucesso.",
                        	cliente
                    };

                    return Ok(result);
                }
                else
                {
                    return BadRequest("Estoque n�o encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet]
        [Produces(typeof(List<ClienteConsultaModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var result = clienteRepository.Consultar();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(ClienteConsultaModel))]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = clienteRepository.ObterPorId(id);

                if (result != null) //se o Cliente foi encontrado..
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent(); //HTTP 204 (SUCESSO -> Vazio)
                }
            }

            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
