using ProjetoAcademico.Domain.Entities.Base;
using ProjetoAcademico.Domain.Enumerators;

namespace ProjetoAcademico.Domain.Entities
{
    public class Professor : EntityBase
    {
        public string Nome { get; private set; }
        public string Biografia { get; private set; }

        public Professor(
            string nome,
            string biografia)
        {
            Nome = nome;
            Biografia = biografia;
        }

        public void Atualizar(
            string nome,
            string biografia)
        {
            Nome = nome;
            Biografia = biografia;
        }
    }
}
