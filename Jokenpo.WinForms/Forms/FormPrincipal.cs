using Jokenpo.Core.Enums;
using Jokenpo.Core.Services;

namespace Jokenpo.WinForms.Forms
{
    public partial class FormPrincipal : Form
    {
        private readonly JogoService _jogoService = new();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        // ──────────────────────────────────────────────
        //  Handlers dos botões de escolha
        // ──────────────────────────────────────────────

        private void btnPedra_Click(object sender, EventArgs e)
            => JogarRodada(OpcaoJogo.Pedra);

        private void btnPapel_Click(object sender, EventArgs e)
            => JogarRodada(OpcaoJogo.Papel);

        private void btnTesoura_Click(object sender, EventArgs e)
            => JogarRodada(OpcaoJogo.Tesoura);

        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            _jogoService.NovoJogo();
            AtualizarPlacar();
            lblResultado.Text      = "Faça sua escolha!";
            lblResultado.ForeColor = Color.White;
            lblEscolhaJogador.Text = "—";
            lblEscolhaPC.Text      = "—";
            listHistorico.Items.Clear();
        }

        // ──────────────────────────────────────────────
        //  Lógica principal da rodada
        // ──────────────────────────────────────────────

        private void JogarRodada(OpcaoJogo escolha)
        {
            var rodada = _jogoService.ProcessarRodada(escolha);

            // Ícones das escolhas
            lblEscolhaJogador.Text = NomeComEmoji(rodada.EscolhaJogador);
            lblEscolhaPC.Text      = NomeComEmoji(rodada.EscolhaComputador);

            // Resultado visual
            switch (rodada.Resultado)
            {
                case ResultadoRodada.Vitoria:
                    lblResultado.Text      = "🎉 Você venceu!";
                    lblResultado.ForeColor = Color.LimeGreen;
                    break;
                case ResultadoRodada.Derrota:
                    lblResultado.Text      = "😏 O computador venceu!";
                    lblResultado.ForeColor = Color.Tomato;
                    break;
                case ResultadoRodada.Empate:
                    lblResultado.Text      = "🤝 Empatamos!";
                    lblResultado.ForeColor = Color.Gold;
                    break;
            }

            // Histórico
            string entrada = $"Rodada {rodada.Numero}: Você={NomeComEmoji(rodada.EscolhaJogador)}  PC={NomeComEmoji(rodada.EscolhaComputador)}  → {ResultadoTexto(rodada.Resultado)}";
            listHistorico.Items.Insert(0, entrada);

            AtualizarPlacar();
        }

        private void AtualizarPlacar()
        {
            var e = _jogoService.Estatisticas;
            lblVitorias.Text  = e.Vitorias.ToString();
            lblDerrotas.Text  = e.Derrotas.ToString();
            lblEmpates.Text   = e.Empates.ToString();
            lblTotalRodadas.Text = $"Total de rodadas: {e.TotalRodadas}";
        }

        // ──────────────────────────────────────────────
        //  Helpers
        // ──────────────────────────────────────────────

        private static string NomeComEmoji(OpcaoJogo opcao) => opcao switch
        {
            OpcaoJogo.Pedra   => "✊ Pedra",
            OpcaoJogo.Papel   => "✋ Papel",
            OpcaoJogo.Tesoura => "✌ Tesoura",
            _                 => "?"
        };

        private static string ResultadoTexto(ResultadoRodada r) => r switch
        {
            ResultadoRodada.Vitoria => "✅ Vitória",
            ResultadoRodada.Derrota => "❌ Derrota",
            ResultadoRodada.Empate  => "🤝 Empate",
            _                       => ""
        };
    }
}
