using EsportesNews_Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EsportesNews_Infra.DAL
{
    public class TabelaDeClassificacaoDAO
    {
        public ObjectId _id { get; set; }

        [BsonElement("Classificacao")]
        public List<ClubesDAO> Classificacao { get; set; }

        [BsonElement("UltimaAtualizacao")]
        public DateTime UltimaAtualizacao { get; set; }
    }
}
