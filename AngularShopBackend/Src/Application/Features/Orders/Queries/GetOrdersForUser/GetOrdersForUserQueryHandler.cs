﻿using Application.Contracts;
using Application.Dtos.OrderDto;
using AutoMapper;
using Domain.Entities.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries.GetOrdersForUser;

public class GetOrdersForUserQuery : IRequest<List<OrderDto>>
{
}

public class GetOrdersForUserQueryHandler : IRequestHandler<GetOrdersForUserQuery, List<OrderDto>>
{
    private readonly IUnitOWork _uow;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetOrdersForUserQueryHandler(IUnitOWork uow, IMapper mapper, ICurrentUserService currentUserService)
    {
        _uow = uow;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<List<OrderDto>> Handle(GetOrdersForUserQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetOrdersByUserSpecification(_currentUserService.UserId);
        var orders = await _uow.Repository<Order>().GetListBySpecAsync(spec,cancellationToken);
        return _mapper.Map<List<OrderDto>>(orders);
    }
}
