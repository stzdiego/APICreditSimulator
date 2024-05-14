// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace ApiCreditSimulator.Shared.Dto;

public class PutDto<T>
{
    public int Id { get; set; }

    public T? Entity { get; set; }
}
