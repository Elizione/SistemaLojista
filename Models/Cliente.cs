using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_lojista.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome/Razão Social é obrigatório"), MaxLength(150)]
        [Display(Name = "Nome do Cliente/Razão Social", Prompt = "Nome completo ou Razão Social do Cliente")]
        public string NomeRazaoSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-mail é obrigatório"), MaxLength(150), EmailAddress]
        [Display(Name = "E-Mail", Prompt = "E-mail do Cliente")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefone é obrigatório"), MaxLength(14)]
        //[RegularExpression(@"\(\d{2}\) \d{5}-\d{4}", ErrorMessage = "Telefone deve estar no formato (##) #####-####")]
        [Display(Name = "Telefone", Prompt = "Telefone do Cliente")]
        public string Telefone { get; set; } = string.Empty;

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Tipo de Pessoa é obrigatório")]
        [Display(Name = "Tipo de Pessoa", Prompt = "Selecione o tipo de Pessoa")]
        public string TipoPessoa { get; set; } = string.Empty;

        [Required(ErrorMessage = "CPF/CNPJ é obrigatório"), MaxLength(18)]
        //[RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}|\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "CPF/CNPJ inválido")]
        [Display(Name = "CPF/CNPJ", Prompt = "Insira o CPF ou o CNPJ do Cliente")]
        public string CPFCNPJ { get; set; } = string.Empty;

        [MaxLength(15)]
        [Display(Name = "Inscrição Estadual", Prompt = "Inscrição Estadual do Cliente, selecionar Isento caso assim for")]
        public string? InscricaoEstadual { get; set; }

        [Display(Name = "Isento")]
        public bool Isento { get; set; }

        [Display(Name = "Gênero", Prompt = "Selecione o gênero do Cliente")]
        public string? Genero { get; set; }

        [Display(Name = "Data de Nascimento", Prompt = "Data de nascimento do Cliente")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Bloqueado", Prompt = "Bloqueio o acesso do Cliente na sua Loja")]
        public bool Bloqueado { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória"), MinLength(8), MaxLength(15)]
        [Display(Name = "Senha", Prompt = "Cadastre a senha de acesso do seu Cliente")]
        public string Senha { get; set; } = string.Empty;

        [NotMapped]
        [Required(ErrorMessage = "Confirmação de Senha é obrigatória"), MinLength(8), MaxLength(15)]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        [Display(Name = "Confirmação de Senha", Prompt = "Confirmação de Senha")]
        public string ConfirmacaoSenha { get; set; } = string.Empty;
    }
}
