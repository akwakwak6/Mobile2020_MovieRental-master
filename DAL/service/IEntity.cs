using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.service {
    public interface IEntity<TKey> {
        TKey Id { get; }
    }
}
