using ProjetoAcademico.Domain.Entities.Base;
using ProjetoAcademico.Domain.Enumerators;

namespace ProjetoAcademico.Domain.Entities
{
    public class Curso : EntityBase
    {
        public string Nome { get; private set; }
        public EnumPeriodo Periodo { get; private set; }
        public string? Descricao { get; private set; }
        public int CargaHoraria { get; private set; }
        public int QuantidadeMaximaAlunos { get; private set; }

        public Curso(
            string nome, 
            EnumPeriodo periodo, 
            string? descricao, 
            int cargaHoraria, 
            int quantidadeMaximaAlunos)
        {
            Nome = nome;
            Periodo = periodo;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            QuantidadeMaximaAlunos = quantidadeMaximaAlunos;
        }

        public void Atualizar(
            string nome, 
            EnumPeriodo periodo, 
            string? descricao, 
            int cargaHoraria,
            int quantidadeMaximaAlunos)
        {
            Nome = nome;
            Periodo = periodo;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            QuantidadeMaximaAlunos = quantidadeMaximaAlunos;
        }
    }
}
