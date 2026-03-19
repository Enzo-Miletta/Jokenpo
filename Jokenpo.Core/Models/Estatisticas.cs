namespace Jokenpo.Core.Models
{
    /// <summary>
    /// Acumula o placar completo de uma sessão de jogo.
    /// </summary>
    public class Estatisticas
    {
        public int Vitorias { get; private set; }
        public int Derrotas { get; private set; }
        public int Empates { get; private set; }
        public int TotalRodadas => Vitorias + Derrotas + Empates;

        public void RegistrarVitoria()  => Vitorias++;
        public void RegistrarDerrota()  => Derrotas++;
        public void RegistrarEmpate()   => Empates++;

        public void Resetar()
        {
            Vitorias = 0;
            Derrotas = 0;
            Empates  = 0;
        }

        public override string ToString()
            => $"Vitórias: {Vitorias} | Derrotas: {Derrotas} | Empates: {Empates}";
    }
}
