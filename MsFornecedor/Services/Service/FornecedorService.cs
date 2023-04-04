using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MsFornecedor.Dtos;
using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Repositorys.Interfaces;
using MsFornecedor.Services.Interfaces;
using MsFornecedor.Validations.Interfaces;

namespace MsFornecedor.Services.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorValidations _fornecedorValidations;
        private readonly IRepositoryFornecedor _repositoryFornecedor;
        private readonly IMapper _mapper;
        public FornecedorService(IFornecedorValidations fornecedorValidations,
            IRepositoryFornecedor repositoryFornecedor,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _repositoryFornecedor = repositoryFornecedor;
            _fornecedorValidations = fornecedorValidations;
        }
        public async Task<bool> AddFornecedor(FornecedorDto fornecedorDto)
        {
            try
            {
                var validacoes = _fornecedorValidations.ValidationsCreate(fornecedorDto);

                if(validacoes.Count > 0)
                {
                    string mensagem = string.Format("Campos obrigatórios:\n{0}", string.Join("\n", validacoes));
                    throw new Exception(mensagem);
                }

                var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

                await _repositoryFornecedor.AddFornecedor(fornecedor);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteFornecedor(int id)
        {
            try
            {
                if (id <= 0) throw new Exception("Id inválido");

                var fornecedor = await this._repositoryFornecedor.GetById(id);

                if (fornecedor == null) throw new Exception("Não foi possível localizar o fornecedor");

                var result = await this._repositoryFornecedor.DeleteFornecedor(fornecedor);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Fornecedor> GetById(int id)
        {
            try
            {
                if (id <= 0) throw new Exception("Id inválido");

                var fornecedor = await this._repositoryFornecedor.GetById(id);

                if (fornecedor == null) throw new Exception("Não foi possível localizar o fornecedor");

                return fornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PaginacaoDto> GetPaginacao(int pagina, string query)
        {
            try
            {
                var paginacaoDto = await this._repositoryFornecedor.GetPaginacao(pagina, query);

                if (paginacaoDto == null) throw new Exception("Ocorreu um erro interno ao listar os fornecedores.");

                return paginacaoDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Fornecedor>> ListaFornecedor()
        {
            try
            {
                var paginacaoDto = await this._repositoryFornecedor.GetAll();

                if (paginacaoDto == null) throw new Exception("Ocorreu um erro interno ao listar os fornecedores.");

                return paginacaoDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateFornecedor(Fornecedor fornecedor)
        {
            try
            {
                var validacoes = _fornecedorValidations.ValidationsEdite(fornecedor);

                if (validacoes.Count > 0)
                {
                    string mensagem = string.Format("Campos obrigatórios:\n{0}", string.Join("\n", validacoes));
                    throw new Exception(mensagem);
                }

                await _repositoryFornecedor.UpdateFornecedor(fornecedor);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
