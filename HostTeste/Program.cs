using Crawler.CW;
using EsportesNews_Domain.Entidades;
using EsportesNews_Infra.DAL;
using System;

namespace HostTeste
{
    class Program
    {
        
        static void Main(string[] args)
        {
            EsporteNEWS esporteNEWS = new EsporteNEWS();
            esporteNEWS.EsporteNewsCrawler();
        }
    }
}
