﻿using MS.WebUI.Models;

namespace MS.WebUI.Services.Interfaces;

public interface IUserService
{
    Task<UserDetailViewModel> GetUserInfo();
    Task<List<UserDetailViewModel>> GetUsersByIdsAsync(List<string> userIds);
}
