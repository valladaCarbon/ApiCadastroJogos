using System.ComponentModel.DataAnnotations;

namespace ApiCadastroJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome do Jogo deve conter entre 3 e 100 Caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Nome da Produtora deve conter entre 1 e 100 Caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "O Preço deve ser de no mínimo 1 real e no máximo 1000 reais")]
        public double Preco{ get; set; }
    }
}