using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsportesNews_Domain.Entidades
{
    public class BrasileiraoGE
    {
        public BrasileiraoGE()
        {

        }

        public ObjectId _id { get; set; }

        [BsonElement("TabelaDeClassificacao")]
        public List<Clubes> TabelaDeClassificacao { get; set; }


        [BsonElement("UltimaAtualizacao")]
        public string UltimaAtualizacao { get; set; }

    }
}
