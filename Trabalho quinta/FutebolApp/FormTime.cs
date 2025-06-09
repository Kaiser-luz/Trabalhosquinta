using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace FutebolApp
{
    public class Time
    {
        public string Nome { get; set; }
        public string Tecnico { get; set; }
        public List<string> Jogadores { get; set; } = new List<string>();
    }

    public partial class FormTime : Form
    {
        private IContainer components;
        private List<Time> times = new List<Time>();
        private ListBox lstResultado = new ListBox();
        private TextBox txtNome = new TextBox();
        private TextBox txtTecnico = new TextBox();
        private TextBox txtJogadores = new TextBox();
        private TextBox txtBusca = new TextBox();

        public FormTime()
        {
            InitializeComponent();
            this.Text = "Gerenciamento de Times";
            this.Size = new Size(600, 400);
            this.BackColor = Color.ForestGreen;
            this.ForeColor = Color.Black;

            Label lblNome = new Label() { Text = "Nome:", Location = new Point(10, 10), AutoSize = true };
            txtNome.Location = new Point(70, 10);

            Label lblTecnico = new Label() { Text = "Técnico:", Location = new Point(10, 40), AutoSize = true };
            txtTecnico.Location = new Point(70, 40);

            Label lblJogadores = new Label() { Text = "Jogadores (separados por vírgula):", Location = new Point(10, 70), AutoSize = true };
            txtJogadores.Location = new Point(10, 90);
            txtJogadores.Size = new Size(300, 20);

            Button btnCadastrar = new Button() { Text = "Cadastrar", Location = new Point(10, 120) };
            btnCadastrar.Click += (s, e) => CadastrarTime(txtNome.Text, txtTecnico.Text, new List<string>(txtJogadores.Text.Split(',')));

            Button btnListar = new Button() { Text = "Listar", Location = new Point(100, 120) };
            btnListar.Click += (s, e) => ListarTimes();

            Label lblBusca = new Label() { Text = "Buscar:", Location = new Point(10, 150), AutoSize = true };
            txtBusca.Location = new Point(70, 150);

            Button btnBuscar = new Button() { Text = "Buscar", Location = new Point(250, 150) };
            btnBuscar.Click += (s, e) => BuscarTime(txtBusca.Text);

            Button btnAtualizar = new Button() { Text = "Atualizar", Location = new Point(10, 180) };
            btnAtualizar.Click += (s, e) => AtualizarTime(txtNome.Text, txtTecnico.Text, new List<string>(txtJogadores.Text.Split(',')));

            Button btnRemover = new Button() { Text = "Remover", Location = new Point(100, 180) };
            btnRemover.Click += (s, e) => RemoverTime(txtNome.Text);

            lstResultado.Location = new Point(10, 220);
            lstResultado.Size = new Size(560, 130);

            Controls.AddRange(new Control[] {
                lblNome, txtNome, lblTecnico, txtTecnico, lblJogadores, txtJogadores,
                btnCadastrar, btnListar, lblBusca, txtBusca, btnBuscar,
                btnAtualizar, btnRemover, lstResultado
            });
        }

        private void InitializeComponent()
        {
            components = new Container();
        }

        private void CadastrarTime(string nome, string tecnico, List<string> jogadores)
        {
            if (!times.Exists(t => t.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
            {
                times.Add(new Time { Nome = nome, Tecnico = tecnico, Jogadores = jogadores });
                MessageBox.Show("Time cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Já existe um time com esse nome.");
            }
        }

        private void ListarTimes()
        {
            lstResultado.Items.Clear();
            foreach (var time in times)
            {
                lstResultado.Items.Add($"{time.Nome} - {time.Tecnico} - Jogadores: {string.Join(", ", time.Jogadores)}");
            }
        }

        private void BuscarTime(string termo)
        {
            lstResultado.Items.Clear();
            foreach (var time in times)
            {
                if (time.Nome.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    time.Tecnico.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lstResultado.Items.Add($"{time.Nome} - {time.Tecnico} - Jogadores: {string.Join(", ", time.Jogadores)}");
                }
            }
        }

        private void AtualizarTime(string nome, string novoTecnico, List<string> novosJogadores)
        {
            var time = times.Find(t => t.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if (time != null)
            {
                time.Tecnico = novoTecnico;
                time.Jogadores = novosJogadores;
                MessageBox.Show("Time atualizado!");
            }
            else
            {
                MessageBox.Show("Time não encontrado.");
            }
        }

        private void RemoverTime(string nome)
        {
            var time = times.Find(t => t.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if (time != null)
            {
                times.Remove(time);
                MessageBox.Show("Time removido.");
            }
            else
            {
                MessageBox.Show("Time não encontrado.");
            }
        }
    }
}
