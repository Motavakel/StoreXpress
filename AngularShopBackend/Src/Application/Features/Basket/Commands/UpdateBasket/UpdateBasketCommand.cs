﻿using Domain.Entities.BasketEntity;
using MediatR;

namespace Application.Features.Basket.Commands.UpdateBasket;

public class UpdateBasketCommand : IRequest<CustomerBasket>
{
    public CustomerBasket CustomerBasket { get; set; }
    public UpdateBasketCommand(CustomerBasket customerBasket)
    {
        CustomerBasket = customerBasket;
    }
}