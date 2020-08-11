using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Data.Repository;
using Projeto.Services.Models.OS;

namespace Projeto.Services.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class OSController : ControllerBase
    {
        //atributo
        private readonly IOSRepository osRepository;
        private readonly IMesReferenciaRepository mesRepository;
        private readonly IContratoRepository contratoRepository;
        private readonly IClienteRepository ClienteRepository;
        private readonly IMapper mapper;

        public OSController(IOSRepository osRepository, IMesReferenciaRepository mesRepository, IContratoRepository contratoRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            this.osRepository = osRepository;
            this.mesRepository = mesRepository;
            this.contratoRepository = contratoRepository;
            ClienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(OSCadastroModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    if (model.Clientes != null)
                    {
                        foreach (var itens in model.Clientes)
                        {

                            var cliente = new Cliente();


                            var contratoAtivo = contratoRepository.Consultar()
                            .FirstOrDefault(co => co.Cod_Cliente.Equals(itens.Cod_Cliente)
                            && co.Flag_Termino.Equals(false));

                            if (contratoAtivo != null)
                            {

                                var os = new OS();

                                os.Cod_Contrato = contratoAtivo.Cod_Contrato;
                                os.Cod_Cliente = itens.Cod_Cliente;
                                os.Data_Geracao = DateTime.Now;
                                os.Data_Coleta = null;
                                os.Flag_Ativo = true;
                                os.Flag_Cancelado = false;
                                os.Quantidade_Coletada = 0;
                                os.Flag_Coleta = false;
                                os.Flag_Cancelado = false;
                                os.Motivo_Cancelamento = null;
                                os.Data_Cancelamento = null;

                                var MesRef = mesRepository.Consultar().FirstOrDefault(m => m.Data_Encerramento == null && m.Flag_Encerramento.Equals(false));

                                if (MesRef == null)
                                {
                                    return StatusCode(403, $"N�o existe M�s refer�ncia aberto para cadastro da OS, favor cadastrar o M�s Refer�ncia");
                                }

                                os.Cod_MesReferencia = MesRef.Cod_MesReferencia;
                                osRepository.Inserir(os);

                            }
                            else
                            {
                                return StatusCode(403, $"N�o existe contrato Ativo para o {itens.Cod_Cliente}.");
                            }
                        }
                    }

                    else
                    {
                        return StatusCode(403, $"Favor selecionar o cliente para gera��o das OSs. ");
                    }



                    var result = new
                    {
                        message = "OS cadastrada com sucesso",                        
                    };

                    return Ok(result);
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
        public IActionResult Put(OSEdicaoModel model)
        {
            //verificando se os campos da model passaram nas �es
            if (ModelState.IsValid)
            {
                try
                {
                    var os = mapper.Map<OS>(model);
                    osRepository.Alterar(os);

                    var result = new
                    {
                        message = "OS atualizado com sucesso",
                        os
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
                //buscar o OS referente ao id informado..
                var os = osRepository.ObterPorId(id);

                //verificar se o OS foi encontrado..
                if (os != null)
                {
                    //excluindo o OS
                    osRepository.Excluir(os);

                    var result = new
                    {
                        message = "OS exclu�do com sucesso.",
                        os
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
        [Produces(typeof(List<OSConsultaModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var result = osRepository.Consultar();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet("{id}")]
        [Produces(typeof(OSConsultaModel))]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = osRepository.ObterPorId(id);

                if (result != null) //se o OS foi encontrado..
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
