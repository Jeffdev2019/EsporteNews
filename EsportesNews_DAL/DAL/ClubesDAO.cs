using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsportesNews_Infra.DAL
{
    public class ClubesDAO
    {

        [BsonElement("equipe_id")]
        public Int64 equipe_id { get; set; }

        [BsonElement("nome_popular")]
        public string nome_popular { get; set; }

        [BsonElement("ordem")]
        public Int64 ordem { get; set; }

        [BsonElement("escudo")]
        public string escudo { get; set; }

        [BsonElement("faixa_classificacao_cor")]
        public string faixa_classificacao_cor { get; set; }

        [BsonElement("pontos")]
        public Int64 pontos { get; set; }

        [BsonElement("jogos")]
        public Int64 jogos { get; set; }

        [BsonElement("vitorias")]
        public Int64 vitorias { get; set; }

        [BsonElement("empates")]
        public Int64 empates { get; set; }

        [BsonElement("derrotas")]
        public Int64 derrotas { get; set; }

        [BsonElement("saldo_gols")]
        public Int64 saldo_gols { get; set; }

        [BsonElement("sigla")]
        public string sigla { get; set; }

        [BsonElement("ultimos_jogos")]
        public List<Ultimos_jogos> ultimos_jogos { get; set; }


        public enum Ultimos_jogos { v, d, e };
    }
}
