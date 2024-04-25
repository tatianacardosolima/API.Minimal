using Microsoft.AspNetCore.SignalR;

namespace API.Minimal.Services
{
    public class ProdutoService
    {
        public List<Produto> Get()
        { 
            List<Produto> list = new List<Produto>();
            for(int i = 0; i < 10; i++)
            {
                list.Add(new Produto(i, $"Desc {i}"));

            }
            return list;
        }

        public void AddNew()
        {
            
        }

        public void Update()
        {

        }
    }

    public record Produto (int id, string description)
    {
    }
}
