using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Página_principal

{
    public partial class PáginaPrincipal : Form
    {
        FlightPlanList vuelosGuardados = new FlightPlanList();
        public PáginaPrincipal()
        {
            InitializeComponent();
        }
        
        private void PlanesDeVuelo_Click(object sender, EventArgs e)
        {
            //Creas la instancia del formulario al que quieres ir
            PlanesDeVuelo formPlanesVuelo = new PlanesDeVuelo();
            //Muestras el nuevo formulario
            formPlanesVuelo.ShowDialog();
            FlightPlanList listaRecuperada = formPlanesVuelo.GetListaVuelos();

            //(GetNumber() nos dice cuántos vuelos hay en el vector)
            if (listaRecuperada.GetNumber() > 0)
            {
                // Guardamos la lista recuperada en nuestra variable del menú principal
                this.vuelosGuardados = listaRecuperada;

                MessageBox.Show("Se han recuperado " + vuelosGuardados.GetNumber() + " planes de vuelo desde el formulario.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParametrosTiempoDistancia formParametros = new ParametrosTiempoDistancia();
            formParametros.ShowDialog(); // Espera a que el usuario cierre la ventana
            // Recuperas los datos guardados usando los Getters
            double distancia = formParametros.GetDistanciaSeguridad();
            double tiempo = formParametros.GetTiempoCiclo();
        }
    }
}
