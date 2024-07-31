
using System;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [StringLength(14, ErrorMessage = "CNPJ deve ter 14 caracteres")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [MaxLength(100, ErrorMessage = "Endereço deve ter no máximo 100 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [StringLength(13, ErrorMessage = "Telefone deve ter 13 caracteres")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
