using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangBang.Models
{

    public class Estado
    {
        private static Dictionary<int, Jugador[]> partidas=new Dictionary<int, Jugador[]>();
        private static int nroPartidas = 0;
        public Datos InicioPartidaRegistro()
        {
            Jugador jugador = new Jugador();
            if (nroPartidas != 0)
            {
                if (partidas[nroPartidas][1] == null)
                {
                    jugador.id = 2;
                    jugador.turno = true;
                    jugador.partida = nroPartidas;
                    jugador.estado = true;
                    Random rnd = new Random();
                    jugador.ubicacion = rnd.Next(100);
                    partidas[nroPartidas][1] = jugador;
                    Datos datos = new Datos();
                    {
                        datos.idUsuario = 2;
                        datos.idPartida = nroPartidas;
                        datos.turno = true;                        
                    }
                    return datos;     
                    //retorno
                }
            }
            nroPartidas++;
            Jugador[] jugadores = { null, null };
            jugador.id = 1;
            jugador.turno = false;
            jugador.partida = nroPartidas;
            jugador.estado = true;
            Random rnd2 = new Random();
            jugador.ubicacion = rnd2.Next(100);
            jugadores[0] = jugador;
            partidas.Add(nroPartidas, jugadores);            
            //while(partidas[nroPartidas][1] == null) { }
            Datos datos2 = new Datos();
            {
                datos2.idUsuario = 1;
                datos2.idPartida = nroPartidas;
                datos2.turno = false;                
            }
            return datos2;           
            //retorno
        }

        public bool InicioPartida(Datos datos)
        {
            if (partidas[datos.idPartida][1] == null)
            {
                return false;
            }
            return true;
        }//retorna true si ya hay cupo completo en la partida y false aun falta un jugador

        public bool Lanzar(DatosLanzamiento datos)
        {
            Jugador oponente = new Jugador();
            if (partidas[datos.idPartida][0].id == datos.idUsr)
            {
                oponente = partidas[datos.idPartida][1];
                partidas[datos.idPartida][0].turno = false;
            }
            else
            {
                oponente = partidas[datos.idPartida][0];
                partidas[datos.idPartida][1].turno = false;
            }
            int alcance = datos.posicion_caida;   
            //double alcance = (Math.Pow(datos.velocidad, 2)/9.8)*Math.Sin(2*datos.angulo);
            if (alcance == oponente.ubicacion)
            {
                oponente.estado = false;
                return true;
            }
            oponente.turno = true;
            return false;
            //retorna true si dio en el blanco, false si no
        }

        public bool Turno(Datos datos)
        {            
            Jugador yo = new Jugador();
            if (partidas[datos.idPartida][0].id == datos.idUsuario)
            {                
                yo = partidas[datos.idPartida][0];
            }
            else
            {               
                yo = partidas[datos.idPartida][1];
            }                      
            if (yo.estado)
                return false;
            else
                return true;  
            //retornar true si fue eliminado, false si no fue atacado          
        }
    }
}