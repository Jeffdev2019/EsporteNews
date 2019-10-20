using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using EsportesNews_Domain.Entidades;

namespace EsportesNews_Infra.DAL
{
    public class DataAccessMDB
    {
        string Conexao = "mongodb://127.0.0.1:27017";

        private MongoClient _cliente;
        private IMongoDatabase _banco;
        private IMongoCollection<BrasileiraoGE> _collection;

        public DataAccessMDB()
        {
             _cliente = new MongoClient(Conexao);
             _banco = _cliente.GetDatabase("EsportesNEWS");
             _collection = _banco.GetCollection<BrasileiraoGE>("TabelasDeClassificacao");
        }
        public List<BrasileiraoGE> GetTabelaDeClassificacaoDAOAsync()
        {
            var lista =_collection.Find(new BsonDocument()).ToList();
            return lista;
        }
        public BrasileiraoGE GetTabelaDeClassificacaoDAO(ObjectId _id)
        {
            var filter = Builders<BrasileiraoGE>.Filter.Eq("_id", _id);
            var filmeUnico = _collection.Find(filter).FirstOrDefault();
            return filmeUnico;
        }
        public BrasileiraoGE Create(BrasileiraoGE tabelaDeClassificacao)
        {
            var adiciona = _collection.InsertOneAsync(tabelaDeClassificacao);
            return tabelaDeClassificacao;
        }
        public async Task<ReplaceOneResult> AtualizaTabelaDeClassificacaoDAO(string _id, BrasileiraoGE tabelaDeClassificacao)
        {
            var codigo = new ObjectId(_id);
            return await _collection.ReplaceOneAsync
              (a => a._id == codigo, tabelaDeClassificacao, new UpdateOptions { IsUpsert = true });
        }
        public async Task<DeleteResult> Remove(ObjectId id)
        {
            var query = Builders<BrasileiraoGE>.Filter.Eq(f => f._id, id);
            return await _collection.DeleteOneAsync(query);
        }

    }
}
