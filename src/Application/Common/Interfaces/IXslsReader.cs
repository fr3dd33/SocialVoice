using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IXslsReader<T>
    {
        Task<T> ReadAsync(string fileName);
    }
}
