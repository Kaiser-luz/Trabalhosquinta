// Projeto 1: Gerenciamento de Biblioteca de Música (Dicionário)
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MusicaApp
{
    public class Musica
    {
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string Genero { get; set; }
    }

    public partial class FormMusica : Form
    {
        private Dictionary<string, Musica> biblioteca = new Dictionary<string, Musica>();
        private ListBox lstResultado = new ListBox();
        private TextBox txtTitulo = new TextBox();
        private TextBox txtArtista = new TextBox();
        private TextBox txtGenero = new TextBox();
        private TextBox txtBusca = new TextBox();

        public FormMusica()
        {
            InitializeComponent();
            this.Text = "Biblioteca de Música";
            this.Size = new Size(600, 400);
            this.BackColor = Color.MediumSeaGreen;
            this.ForeColor = Color.Black; // Altera a cor do texto do formulário para preto

            Label lblTitulo = new Label() { Text = "Título:", Location = new Point(10, 10), AutoSize = true, ForeColor = Color.Black };
            txtTitulo.Location = new Point(70, 10);
            txtTitulo.ForeColor = Color.Black;

            Label lblArtista = new Label() { Text = "Artista:", Location = new Point(10, 40), AutoSize = true, ForeColor = Color.Black };
            txtArtista.Location = new Point(70, 40);
            txtArtista.ForeColor = Color.Black;

            Label lblGenero = new Label() { Text = "Gênero:", Location = new Point(10, 70), AutoSize = true, ForeColor = Color.Black };
            txtGenero.Location = new Point(70, 70);
            txtGenero.ForeColor = Color.Black;

            Button btnCadastrar = new Button() { Text = "Cadastrar", Location = new Point(10, 100), ForeColor = Color.Black };
            btnCadastrar.Click += (s, e) => CadastrarMusica(txtTitulo.Text, txtArtista.Text, txtGenero.Text);

            Button btnListar = new Button() { Text = "Listar", Location = new Point(100, 100), ForeColor = Color.Black };
            btnListar.Click += (s, e) => ListarMusicas();

            Label lblBusca = new Label() { Text = "Buscar:", Location = new Point(10, 140), AutoSize = true, ForeColor = Color.Black };
            txtBusca.Location = new Point(70, 140);
            txtBusca.ForeColor = Color.Black;

            Button btnBuscar = new Button() { Text = "Buscar", Location = new Point(250, 140), ForeColor = Color.Black };
            btnBuscar.Click += (s, e) => BuscarMusica(txtBusca.Text);

            Button btnAtualizar = new Button() { Text = "Atualizar", Location = new Point(10, 170), ForeColor = Color.Black };
            btnAtualizar.Click += (s, e) => AtualizarMusica(txtTitulo.Text, txtArtista.Text, txtGenero.Text);

            Button btnRemover = new Button() { Text = "Remover", Location = new Point(100, 170), ForeColor = Color.Black };
            btnRemover.Click += (s, e) => RemoverMusica(txtTitulo.Text);

            lstResultado.Location = new Point(10, 210);
            lstResultado.Size = new Size(560, 140);
            lstResultado.ForeColor = Color.Black;

            Controls.AddRange(new Control[] {
                lblTitulo, txtTitulo, lblArtista, txtArtista, lblGenero, txtGenero,
                btnCadastrar, btnListar, lblBusca, txtBusca, btnBuscar,
                btnAtualizar, btnRemover, lstResultado
            });
        }

        private void CadastrarMusica(string titulo, string artista, string genero)
        {
            if (!biblioteca.ContainsKey(titulo))
            {
                biblioteca[titulo] = new Musica { Titulo = titulo, Artista = artista, Genero = genero };
                MessageBox.Show("Música cadastrada com sucesso!");
            }
            else
            {
                MessageBox.Show("Já existe uma música com esse título.");
            }
        }

        private void ListarMusicas()
        {
            lstResultado.Items.Clear();
            foreach (var musica in biblioteca.Values)
            {
                lstResultado.Items.Add($"{musica.Titulo} - {musica.Artista} - {musica.Genero}");
            }
        }

        private void BuscarMusica(string termo)
        {
            lstResultado.Items.Clear();
            foreach (var musica in biblioteca.Values)
            {
                if (musica.Titulo.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    musica.Artista.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    musica.Genero.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lstResultado.Items.Add($"{musica.Titulo} - {musica.Artista} - {musica.Genero}");
                }
            }
        }

        private void AtualizarMusica(string titulo, string novoArtista, string novoGenero)
        {
            if (biblioteca.ContainsKey(titulo))
            {
                biblioteca[titulo].Artista = novoArtista;
                biblioteca[titulo].Genero = novoGenero;
                MessageBox.Show("Informações atualizadas!");
            }
            else
            {
                MessageBox.Show("Música não encontrada.");
            }
        }

        private void RemoverMusica(string titulo)
        {
            if (biblioteca.Remove(titulo))
                MessageBox.Show("Música removida.");
            else
                MessageBox.Show("Música não encontrada.");
        }
    }
}
