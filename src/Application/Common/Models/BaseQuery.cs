using MediatR;

namespace Application.Common.Models
{
    public class BaseQuery<T> : IRequest<BaseView<T>>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Search { get; set; }
    }
}
