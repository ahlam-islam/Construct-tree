using TreeAPI.Model;
using MongoDB.Driver;

namespace TreeAPI.Services
{
    public class NodeServices : INodeServices
    {
        private readonly IMongoCollection<Node> _node;

        public NodeServices(ITreeDatabaseSettings settings , IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.TreeDatabaseName);
            _node = database.GetCollection<Node>(settings.TreeCollectionName);
        }

        public List<Node> GetNodes()
        {
            return _node.Find(node => true).ToList();
        }

        public Node GetNode(string id)
        {
        
            return _node.Find(node => node.Id == id).FirstOrDefault();
        }

        public Node AddNode(Node node)
        {
            _node.InsertOne(node);
            return node;
        }
        public void UpdateNode(string id, Node node)
        {
            _node.ReplaceOne(node => node.Id == id, node);
        }
        public void DeleteNode(string id)
        {
            _node.DeleteOne(node => node.Id == id);
        }

    }
}
