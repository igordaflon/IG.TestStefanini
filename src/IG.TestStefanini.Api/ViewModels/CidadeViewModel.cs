using System.ComponentModel.DataAnnotations;

namespace IG.TestStefanini.Api.ViewModels
{
    public class CidadeViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Uf { get; set; } = string.Empty;
    }
}
