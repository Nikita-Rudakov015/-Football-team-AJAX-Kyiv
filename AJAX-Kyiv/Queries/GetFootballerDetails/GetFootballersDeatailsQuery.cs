﻿using System;
using MediatR;

namespace Footballers.Application.Footballers.Queries.GetFootballerDetails
{
    public class GetFootballersDeatailsQuery : IRequest<FootballerDetailsVm>
    {
        public Guid UserId { get; set; }
        public int Id { get; set; }
    }
}
