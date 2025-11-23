using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Pratica5
{
    public partial class FormOrdenacao : Form
    {
        int[] vet = new int[500];

        public FormOrdenacao()
        {
            InitializeComponent();

            // Configura o DoubleBuffered para evitar piscar a tela (Flickering)
            panel.Paint += new PaintEventHandler(panel_Paint);
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panel, new object[] { true });

            // Define uma seleção padrão para o ComboBox para evitar erros
            ordemInicial.SelectedIndex = 2; 
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < vet.Length; i++)
            {
                // Desenha linhas vermelhas representando os valores
                e.Graphics.DrawLine(Pens.Red, i, panel.Height - 1, i, panel.Height - 1 - vet[i]);
            }
        }

        private void iniciaAnimacao(Action a)
        {
            if (bgw.IsBusy != true)
            {

                int opcao = ordemInicial.SelectedIndex;
                int alturaPainel = panel.Height;

                // Preenche o vetor de acordo com a escolha do usuário
                switch (opcao)
                {
                    case 0:
                        Preenchimento.Crescente(vet, alturaPainel);
                        break;
                    case 1:
                        Preenchimento.Decrescente(vet, alturaPainel);
                        break;
                    case 2:
                    default:
                        Preenchimento.Aleatorio(vet, alturaPainel);
                        break;
                }

                // Força um redesenho inicial para mostrar o estado antes de ordenar
                panel.Invalidate();

                bgw.RunWorkerAsync(a); // Inicia a animação em segundo plano
            }
            else
            {
                MessageBox.Show(this,
                   "Aguarde o fim da execução atual...",
                   "Prática 5 2025/2 - Métodos de Ordenação",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }


        private void bolhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Bolha(vet, panel));
        }


        private void seleçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Selecao(vet, panel));
        }

        private void inserçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.Insercao(vet, panel));
        }

        private void shellsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.ShellSort(vet, panel));
        }

        private void heapsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.HeapSort(vet, panel));
        }

        private void quicksortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.QuickSort(vet, panel));
        }

        private void mergesortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniciaAnimacao(() => OrdenacaoGrafica.MergeSort(vet, panel));
        }


        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string nomeAluno = "Carlos Henrique Queiroz Ramos Teixeira";
            string matricula = "72401001";

            MessageBox.Show(this,
                "Prática 5 2025/2 - Métodos de Ordenação\n\n" +
                "Desenvolvido por:\n" + matricula + " - " + nomeAluno + "\n" +
                "Prof. Virgílio Borges de Oliveira\n\n" +
                "Algoritmos e Estruturas de Dados\n" +
                "Faculdade COTEMIG\n" +
                "Apenas para fins didáticos.",
                "Sobre o trabalho...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Action a = (Action)e.Argument;
            a(); // Executa o método de ordenação passado
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(this,
               "Animação concluída!",
               "Prática 5 2025/2 - Métodos de Ordenação",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        private void ordemInicial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}