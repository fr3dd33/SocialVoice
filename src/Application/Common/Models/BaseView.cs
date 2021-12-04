using System.Collections.Generic;

namespace Application.Common.Models
{
    public class BaseView<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Total { get; set; }
    }
}
