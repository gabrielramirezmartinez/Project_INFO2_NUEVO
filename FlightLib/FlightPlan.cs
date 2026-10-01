using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id; // identificador
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
        }

        // Metodos

        public string GetId()
        { return id; }
        public void SetId(string id)
        { this.id = id; }
        public Position GetCurrentPosition()
        { return currentPosition; }
        public void SetCurrentPosition(Position currentPosition)
        { this.currentPosition = currentPosition; }
        public Position GetFinalPosition()
        { return finalPosition; }
        public void SetFinalPosition(Position finalPosition)
        { this.finalPosition = finalPosition; }
        public double GetVelocidad()
        { return velocidad; }
        public void SetVelocidad(double velocidad)
        { this.velocidad = velocidad; }

        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            // Modificar MoverVuelo para que no se pase del destino
            Position nextPosition = new Position(x, y);

            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }
        // Hacer un metodo que diga si un vuelo ha llegado a su destino
        public bool EstaDestino()
        {
            bool resultado = false;
            if (currentPosition == finalPosition)
                resultado = true;
            return resultado;
        }

        // Hacer un metodo que detecte el conflicto cuando dos vuelos están más cerca de la distancia de seguridad
        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                conflicto = true;
            return conflicto;
        }
        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            // Buscar como ecribir datos reales con solo dos decimales
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.EstaDestino())
                Console.WriteLine("Ha llegado al destino");
            Console.WriteLine("******************************");
        }
    }
}