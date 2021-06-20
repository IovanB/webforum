﻿using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace Application.Repositories.Interfaces
{
    public interface ITopicReadOnlyUseCase : IReadOnlyUseCase<Topic>{}
}
