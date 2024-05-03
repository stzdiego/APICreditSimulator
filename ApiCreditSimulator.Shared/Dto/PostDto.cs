// <copyright file="PostDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Shared.Dto;

public class PostDto<T>
{
    public T? Entity { get; set; }
}
