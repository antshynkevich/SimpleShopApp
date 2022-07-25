﻿using VideoCourseProject.Models;

namespace VideoCourseProject.Interfaces;

public interface ICartRepository
{
    Cart? TryGetByUserId(string userId);
    void Add(ProductViewModel productViewModel, string userId);
    void DecreaseAmount(Guid itemId, string userId);
    void IncreaseAmount(Guid itemId, string userId);
    void Clear(string userId);
}
