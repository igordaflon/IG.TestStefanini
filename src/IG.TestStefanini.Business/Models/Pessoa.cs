namespace IG.TestStefanini.Business.Models
{
    public class Pessoa : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public int Idade { get; set; }


        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; } = default!;
    }
}
