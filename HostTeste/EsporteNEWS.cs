using Crawler.CW;
using EsportesNews_Domain.Entidades;
using EsportesNews_Infra.DAL;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostTeste
{
    public class EsporteNEWS
    {
        public DataAccessMDB _dataAccess;

        public EsporteNEWS()
        {
            _dataAccess = new DataAccessMDB();
        }
        public void EsporteNewsCrawler()
        {
            BrasileiraoGE tabeladeClassificacao = new BrasileiraoGE();
            tabeladeClassificacao = CrawlerGE.GetClubesHtml();


            _dataAccess.Create(tabeladeClassificacao);

            List<BrasileiraoGE> tabeladeClassificacaol = _dataAccess.GetTabelaDeClassificacaoDAOAsync();



            /*foreach (var item in tabeladeClassificacao.Classificacao)
            {
                if (item.ordem < 10)
                {
                    Console.WriteLine("[0" + item.ordem + "] - " + item.nome_popular + " - " + item.pontos);
                }
                else
                {
                    Console.WriteLine("[" + item.ordem + "] - " + item.nome_popular + " - " + item.pontos);
                }

            }*/

            Console.ReadLine();

        }
    }
}
