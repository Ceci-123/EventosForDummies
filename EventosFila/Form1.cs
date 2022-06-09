using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventosFila
{
    public partial class Form1 : Form
    {
        public delegate void DelegadoCreado();
        public event DelegadoCreado HayMuchosEnLaLista;
        public Queue<int> lista;
       
        public Form1()
        {
            InitializeComponent();
            lista = new Queue<int>();
        }

        public void ControlarLista()
        {
            if(lista.Count > 2)
            {

                
                if(HayMuchosEnLaLista is not null)
                {
                    HayMuchosEnLaLista.Invoke();

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lista.Enqueue(1);
            this.label1.Text = lista.Count.ToString();
            ControlarLista();
        }

        public void MetodoMagico()
        {
            MessageBox.Show("hola");
        }
        public void MetodoSuperMagico()
        {
            MessageBox.Show("que");
        }
        public void MetodoExtraMagico()
        {
            MessageBox.Show("tal");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HayMuchosEnLaLista = MetodoMagico;
            HayMuchosEnLaLista += MetodoSuperMagico;
            HayMuchosEnLaLista += MetodoExtraMagico;

        }
    }
}
