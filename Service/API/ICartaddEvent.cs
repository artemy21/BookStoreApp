using System;
using Model.ItemModels;

namespace Service.API
{
    public interface ICartaddEvent
    {
        event Action<AbstractItem, int> CartAddEvent;
    }
}