﻿using System;
using System.Collections.Generic;

namespace MessmeApi.Models;


public partial class HomeData
{
    public long id { get; set; }

    public string? message { get; set; }

    public DateOnly? create_date { get; set; }

    public DateOnly? update_date { get; set; }
}
