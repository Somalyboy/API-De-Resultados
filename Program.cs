using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using CapaLogica;
using Newtonsoft.Json;
using System.Data;


namespace API_De_Resultados
{
    public class Program
    {
        static void Main(string[] args)
        {

            HttpListener listener = new HttpListener();
            string url = "http://127.0.0.1:8888/";
            listener.Prefixes.Add(url);
            listener.Start();

            while (true)
            {
                HttpListenerContext contexto = listener.GetContext();

                HttpListenerRequest solicitud = contexto.Request;
                HttpListenerResponse respuesta = contexto.Response;

                Respuesta r = new Respuesta(solicitud, respuesta);

                //buscar info

                System.IO.Stream output = r.respuesta.OutputStream;
                output.Write(r.memoria, 0, r.memoria.Length);

                output.Close();
            }

        }
    }
}
