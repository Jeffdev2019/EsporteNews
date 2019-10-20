using EsportesNews_Domain.Entidades;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Crawler.CW
{
    public static class CrawlerGE
    {
        public static BrasileiraoGE GetClubesHtml()
        {
            WebClient webClient = new WebClient();
            HtmlDocument document = new HtmlDocument();

            webClient.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:68.0) Gecko/20100101 Firefox/68.0");
            webClient.Encoding = Encoding.UTF8;

            string pagina = webClient.DownloadString("https://globoesporte.globo.com/futebol/brasileirao-serie-a/");

            document.LoadHtml(pagina);

            var vb2 = document.DocumentNode.SelectNodes("//div[@class='column small-24 medium-centered medium-20 large-22 tabela-body']/script[@id='scriptReact']");
            string[] json = vb2[0].ChildNodes[0].InnerHtml.Split("const");

            //GetListaDeJogos(json);

            return GetTabelaJson(json);

        }

        private static void GetListaDeJogos(string[] json)
        {
            
        }

        private static BrasileiraoGE GetTabelaJson(string[] json)
        {
            string Classi;
            string[] Classi2 = null;
            BrasileiraoGE tabelaDeClassificacao = new BrasileiraoGE();

            for (int i = 0; i != json.Length; i++)
            {
                if (json[i].Contains("classificacao = "))
                {
                    Classi = json[i].Replace("classificacao = ", "");
                    Classi2 = Classi.ToString().Split("}],");
                }
            }
            for (int i = 0; i != Classi2.Length; i++)
            {
                Classi2[i] = Classi2[i] + "}]}";
                if (Classi2[i].Contains("\"classificacao"))
                {
                    Classi2[i] = Classi2[i].Replace("\"", "'");
                    tabelaDeClassificacao = JsonConvert.DeserializeObject<BrasileiraoGE>(Classi2[i]);
                }
                if (Classi2[i].Contains("\"lista_jogos\":"))
                {
                    Classi2[i] = Classi2[i].Replace("\"", "'");
                    Classi2[i] = "{" + Classi2[i] + "}";


                }
            }
            tabelaDeClassificacao.UltimaAtualizacao = DateTime.Now.ToString("MM/dd/yyyy");




            return tabelaDeClassificacao;
        }
    }
}
