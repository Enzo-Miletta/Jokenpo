using Jokenpo.Core.Enums;

namespace Jokenpo.Core.Models
{
    /// <summary>
    /// Representa uma rodada individual: escolhas de cada jogador e o resultado.
    /// </summary>
    public class Rodada
    {
        public int Numero { get; set; }
        public OpcaoJogo EscolhaJogador { get; set; }
        public OpcaoJogo EscolhaComputador { get; set; }
        public ResultadoRodada Resultado { get; private set; }

        public Rodada(int numero, OpcaoJogo escolhaJogador, OpcaoJogo escolhaComputador)
        {
            Numero            = numero;
            EscolhaJogador    = escolhaJogador;
            EscolhaComputador = escolhaComputador;
            Resultado         = CalcularResultado();
        }

        private ResultadoRodada CalcularResultado()
        {
            if (EscolhaJogador == EscolhaComputador)
                return ResultadoRodada.Empate;

            bool jogadorVence =
                (EscolhaJogador == OpcaoJogo.Pedra   && EscolhaComputador == OpcaoJogo.Tesoura) ||
                (EscolhaJogador == OpcaoJogo.Papel    && EscolhaComputador == OpcaoJogo.Pedra)   ||
                (EscolhaJogador == OpcaoJogo.Tesoura  && EscolhaComputador == OpcaoJogo.Papel);

            return jogadorVence ? ResultadoRodada.Vitoria : ResultadoRodada.Derrota;
        }
    }
}
