using Jokenpo.Core.Enums;
using Jokenpo.Core.Models;

namespace Jokenpo.Core.Services
{
    /// <summary>
    /// Orquestra a lógica do jogo: gera jogada do computador,
    /// processa rodadas e atualiza as estatísticas.
    /// </summary>
    public class JogoService
    {
        private readonly Random _random = new();
        public Estatisticas Estatisticas { get; } = new();
        public List<Rodada> Historico { get; } = new();

        /// <summary>Gera uma escolha aleatória para o computador.</summary>
        public OpcaoJogo GerarEscolhaComputador()
            => (OpcaoJogo)_random.Next(3);

        /// <summary>
        /// Processa uma rodada com a escolha do jogador,
        /// atualiza o histórico e as estatísticas.
        /// </summary>
        public Rodada ProcessarRodada(OpcaoJogo escolhaJogador)
        {
            var escolhaPC = GerarEscolhaComputador();
            int numero    = Historico.Count + 1;
            var rodada    = new Rodada(numero, escolhaJogador, escolhaPC);

            Historico.Add(rodada);

            switch (rodada.Resultado)
            {
                case ResultadoRodada.Vitoria: Estatisticas.RegistrarVitoria(); break;
                case ResultadoRodada.Derrota: Estatisticas.RegistrarDerrota(); break;
                case ResultadoRodada.Empate:  Estatisticas.RegistrarEmpate();  break;
            }

            return rodada;
        }

        /// <summary>Reinicia o jogo, limpando histórico e placar.</summary>
        public void NovoJogo()
        {
            Historico.Clear();
            Estatisticas.Resetar();
        }
    }
}
