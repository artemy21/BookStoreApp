using System;
using Model.ItemModels;

namespace Service.API
{
    public interface IAddEvent
    {
        event Action<AbstractItem> AddItemEvent;
    }
}
