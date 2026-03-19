namespace Jokenpo.Core.Models
{
    /// <summary>
    /// Representa um participante da partida (humano ou computador).
    /// </summary>
    public class Jogador
    {
        public string Nome { get; set; }
        public bool EhComputador { get; set; }

        public Jogador(string nome, bool ehComputador = false)
        {
            Nome = nome;
            EhComputador = ehComputador;
        }

        public override string ToString() => Nome;
    }
}
