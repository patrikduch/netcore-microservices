﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.SignalR.Handlers
{
    public static class TestHandler
    {
        public static HashSet<string> ConnectedIds = new HashSet<string>();
    }
}