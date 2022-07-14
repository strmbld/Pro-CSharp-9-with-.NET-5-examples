using System;
using System.Collections.Generic;

static void ImplicitType()
{
    dynamic a = new List<int> { 90 };
    a = "hello";
}