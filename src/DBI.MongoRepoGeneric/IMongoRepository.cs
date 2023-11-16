using System.Linq.Expressions;

namespace DBI.MongoRepoGeneric
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        
        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);

        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        TDocument FindById(string id);

        void InsertOne(TDocument document);

        Task InsertOneAsync(TDocument document);

        void InsertMany(ICollection<TDocument> documents);

        Task InsertManyAsync(ICollection<TDocument> documents);

        void DeleteOne(Expression<Func<TDocument, bool>> filterExpression);

        void DeleteById(string id);

        void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);
    }
}