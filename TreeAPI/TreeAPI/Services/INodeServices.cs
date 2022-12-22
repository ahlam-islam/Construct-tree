using TreeAPI.Model;

namespace TreeAPI.Services
{
    public interface INodeServices
    {
        List<Node> GetNodes();
        Node GetNode(string id);
        Node AddNode(Node node);
        void UpdateNode(string id, Node node);
        void DeleteNode(string id);
    }
}
