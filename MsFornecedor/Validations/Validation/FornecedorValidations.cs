using MsFornecedor.Dtos;
using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Validations.Interfaces;

namespace MsFornecedor.Validations.Validation
{
    public class FornecedorValidations : IFornecedorValidations
    {
        public List<string> ValidationsCreate(FornecedorDto fornecedorDto)
        {
			try
			{
                var validacoes = new List<string>();

                if (fornecedorDto == null)
                {
                    throw new Exception("Dados do fornecedor nulos");
                }

                if (string.IsNullOrEmpty(fornecedorDto.NomeFornecedor.Trim()))
                {
                    validacoes.Add("Nome do fornecedor é obrigatório.");
                }

                if (string.IsNullOrEmpty(fornecedorDto.NomeFantasia.Trim()))
                {
                    validacoes.Add("Nome fantasia do fornecedor é obrigatório.");
                }

                if(string.IsNullOrEmpty(fornecedorDto.Cpf.Trim()) && string.IsNullOrEmpty(fornecedorDto.Cnpj.Trim()))
                {
                    validacoes.Add("É obrigatório informar o CPF ou o CNPJ.");
                }

                if (string.IsNullOrEmpty(fornecedorDto.InscricaoEstadual.Trim()))
                {
                    validacoes.Add("Inscrição estadual é obrigatório.");
                }

                if (fornecedorDto.EstadoId <= 0)
                {
                    validacoes.Add("É obrigatório selecionar o estado do fornecedor.");
                }

                return validacoes;
            }
			catch (Exception ex)
			{
                throw new Exception(ex.Message);
			}
        }

        public List<string> ValidationsEdite(Fornecedor fornecedor)
        {
            try
            {
                var validacoes = new List<string>();

                if (fornecedor == null)
                {
                    throw new Exception("Dados do fornecedor nulos");
                }

                if (string.IsNullOrEmpty(fornecedor.NomeFornecedor.Trim()))
                {
                    validacoes.Add("Nome do fornecedor é obrigatório.");
                }

                if (string.IsNullOrEmpty(fornecedor.NomeFantasia.Trim()))
                {
                    validacoes.Add("Nome fantasia do fornecedor é obrigatório.");
                }

                if (string.IsNullOrEmpty(fornecedor.Cpf.Trim()) && string.IsNullOrEmpty(fornecedor.Cnpj.Trim()))
                {
                    validacoes.Add("É obrigatório informar o CPF ou o CNPJ.");
                }

                if (string.IsNullOrEmpty(fornecedor.InscricaoEstadual.Trim()))
                {
                    validacoes.Add("Inscrição estadual é obrigatório.");
                }

                if (fornecedor.EstadoId <= 0)    
                {
                    validacoes.Add("É obrigatório selecionar o estado do fornecedor.");
                }

                return validacoes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
