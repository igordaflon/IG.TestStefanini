using System.ComponentModel.DataAnnotations;

namespace IG.TestStefanini.Api.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public int Idade { get; set; }

        public int CidadeId { get; set; }
    }
}
