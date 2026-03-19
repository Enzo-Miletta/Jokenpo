namespace Jokenpo.WinForms.Forms
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        // ── Controles ──────────────────────────────────
        private Panel   panelTopo;
        private Label   lblTitulo;

        private GroupBox grpEscolha;
        private Button  btnPedra;
        private Button  btnPapel;
        private Button  btnTesoura;

        private GroupBox grpArena;
        private Label   lblNomeJogador;
        private Label   lblEscolhaJogador;
        private Label   lblVS;
        private Label   lblNomePC;
        private Label   lblEscolhaPC;

        private Label   lblResultado;

        private GroupBox grpPlacar;
        private Label   lblVitoriasTitulo;
        private Label   lblVitorias;
        private Label   lblDerrotasTitulo;
        private Label   lblDerrotas;
        private Label   lblEmpatesTitulo;
        private Label   lblEmpates;
        private Label   lblTotalRodadas;

        private GroupBox   grpHistorico;
        private ListBox    listHistorico;

        private Button  btnNovoJogo;

        // ───────────────────────────────────────────────

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ── Form ───────────────────────────────────
            this.Text            = "Jokenpo";
            this.Size            = new Size(700, 680);
            this.MinimumSize     = new Size(700, 680);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.BackColor       = Color.FromArgb(30, 30, 46);
            this.ForeColor       = Color.White;
            this.Font            = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;

            // ── Topo ──────────────────────────────────
            panelTopo = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 64,
                BackColor = Color.FromArgb(17, 17, 27)
            };

            lblTitulo = new Label
            {
                Text      = "✊✋✌  JOKENPO",
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(203, 166, 247)
            };

            panelTopo.Controls.Add(lblTitulo);

            // ── Escolha ───────────────────────────────
            grpEscolha = CriarGroupBox("Sua Escolha", 12, 72, 668, 90);

            btnPedra   = CriarBotaoJogo("✊\nPedra",   10, 20, OpcaoJogo: OpcaoJogo.Pedra);
            btnPapel   = CriarBotaoJogo("✋\nPapel",  220, 20, OpcaoJogo: OpcaoJogo.Papel);
            btnTesoura = CriarBotaoJogo("✌\nTesoura", 430, 20, OpcaoJogo: OpcaoJogo.Tesoura);

            btnPedra.Click   += btnPedra_Click;
            btnPapel.Click   += btnPapel_Click;
            btnTesoura.Click += btnTesoura_Click;

            grpEscolha.Controls.AddRange(new Control[] { btnPedra, btnPapel, btnTesoura });

            // ── Arena ─────────────────────────────────
            grpArena = CriarGroupBox("Arena", 12, 170, 668, 130);

            lblNomeJogador = CriarLabel("Você", 50, 22, 160, 22, FontStyle.Bold, ContentAlignment.MiddleCenter);
            lblEscolhaJogador = CriarLabel("—", 20, 50, 220, 50, FontStyle.Regular, ContentAlignment.MiddleCenter);
            lblEscolhaJogador.Font = new Font("Segoe UI", 16F);

            lblVS = CriarLabel("VS", 280, 50, 80, 50, FontStyle.Bold, ContentAlignment.MiddleCenter);
            lblVS.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblVS.ForeColor = Color.FromArgb(203, 166, 247);

            lblNomePC = CriarLabel("Computador", 390, 22, 240, 22, FontStyle.Bold, ContentAlignment.MiddleCenter);
            lblEscolhaPC = CriarLabel("—", 390, 50, 240, 50, FontStyle.Regular, ContentAlignment.MiddleCenter);
            lblEscolhaPC.Font = new Font("Segoe UI", 16F);

            grpArena.Controls.AddRange(new Control[]
            {
                lblNomeJogador, lblEscolhaJogador,
                lblVS,
                lblNomePC, lblEscolhaPC
            });

            // ── Resultado ─────────────────────────────
            lblResultado = new Label
            {
                Text      = "Faça sua escolha!",
                Location  = new Point(12, 308),
                Size      = new Size(668, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Font      = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White
            };

            // ── Placar ────────────────────────────────
            grpPlacar = CriarGroupBox("Placar", 12, 356, 668, 100);

            lblVitoriasTitulo = CriarLabel("Vitórias", 30,  26, 180, 20, FontStyle.Regular, ContentAlignment.MiddleCenter);
            lblVitorias       = CriarLabel("0",        30,  50, 180, 32, FontStyle.Bold,    ContentAlignment.MiddleCenter);
            lblVitorias.Font      = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblVitorias.ForeColor = Color.LimeGreen;

            lblDerrotasTitulo = CriarLabel("Derrotas",  240, 26, 180, 20, FontStyle.Regular, ContentAlignment.MiddleCenter);
            lblDerrotas       = CriarLabel("0",         240, 50, 180, 32, FontStyle.Bold,    ContentAlignment.MiddleCenter);
            lblDerrotas.Font      = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDerrotas.ForeColor = Color.Tomato;

            lblEmpatesTitulo  = CriarLabel("Empates",   450, 26, 180, 20, FontStyle.Regular, ContentAlignment.MiddleCenter);
            lblEmpates        = CriarLabel("0",         450, 50, 180, 32, FontStyle.Bold,    ContentAlignment.MiddleCenter);
            lblEmpates.Font      = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblEmpates.ForeColor = Color.Gold;

            lblTotalRodadas = new Label
            {
                Text      = "Total de rodadas: 0",
                Location  = new Point(0, 82),
                Size      = new Size(660, 16),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(150, 150, 170),
                Font      = new Font("Segoe UI", 8F)
            };

            grpPlacar.Controls.AddRange(new Control[]
            {
                lblVitoriasTitulo, lblVitorias,
                lblDerrotasTitulo, lblDerrotas,
                lblEmpatesTitulo,  lblEmpates,
                lblTotalRodadas
            });

            // ── Histórico ─────────────────────────────
            grpHistorico = CriarGroupBox("Histórico de Rodadas", 12, 464, 668, 130);

            listHistorico = new ListBox
            {
                Location    = new Point(8, 20),
                Size        = new Size(650, 100),
                BackColor   = Color.FromArgb(49, 50, 68),
                ForeColor   = Color.White,
                BorderStyle = BorderStyle.None,
                Font        = new Font("Segoe UI", 9F)
            };

            grpHistorico.Controls.Add(listHistorico);

            // ── Botão Novo Jogo ───────────────────────
            btnNovoJogo = new Button
            {
                Text      = "🔄  Novo Jogo",
                Location  = new Point(240, 600),
                Size      = new Size(200, 40),
                BackColor = Color.FromArgb(203, 166, 247),
                ForeColor = Color.FromArgb(17, 17, 27),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 11F, FontStyle.Bold),
                Cursor    = Cursors.Hand
            };
            btnNovoJogo.FlatAppearance.BorderSize = 0;
            btnNovoJogo.Click += btnNovoJogo_Click;

            // ── Adicionar ao Form ──────────────────────
            this.Controls.AddRange(new Control[]
            {
                panelTopo,
                grpEscolha,
                grpArena,
                lblResultado,
                grpPlacar,
                grpHistorico,
                btnNovoJogo
            });
        }

        // ── Helpers de criação de controles ───────────

        private enum OpcaoJogo { Pedra, Papel, Tesoura }   // local, apenas para o designer

        private GroupBox CriarGroupBox(string texto, int x, int y, int w, int h)
        {
            return new GroupBox
            {
                Text      = texto,
                Location  = new Point(x, y),
                Size      = new Size(w, h),
                ForeColor = Color.FromArgb(203, 166, 247),
                Font      = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
        }

        private Button CriarBotaoJogo(string texto, int x, int y, OpcaoJogo OpcaoJogo)
        {
            var btn = new Button
            {
                Text      = texto,
                Location  = new Point(x, y),
                Size      = new Size(210, 55),
                BackColor = Color.FromArgb(49, 50, 68),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 13F),
                Cursor    = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(203, 166, 247);
            btn.FlatAppearance.BorderSize  = 1;

            // Hover
            btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(88, 91, 112);
            btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(49, 50, 68);

            return btn;
        }

        private Label CriarLabel(string texto, int x, int y, int w, int h,
                                  FontStyle estilo, ContentAlignment alinhamento)
        {
            return new Label
            {
                Text      = texto,
                Location  = new Point(x, y),
                Size      = new Size(w, h),
                Font      = new Font("Segoe UI", 10F, estilo),
                ForeColor = Color.White,
                TextAlign = alinhamento
            };
        }
    }
}
