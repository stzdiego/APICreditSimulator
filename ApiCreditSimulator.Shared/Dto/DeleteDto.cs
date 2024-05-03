// <copyright file="DeleteDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Shared.Dto;

public class DeleteDto<T>
{
    public T? Entity { get; set; }
}
