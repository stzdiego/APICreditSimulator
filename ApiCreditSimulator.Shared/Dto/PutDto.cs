// <copyright file="PutDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ApiCreditSimulator.Shared.Dto;

public class PutDto<T>
{
    public int Id { get; set; }

    public T? Entity { get; set; }
}
