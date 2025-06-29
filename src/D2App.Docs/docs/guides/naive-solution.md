---
title: Naive Implementation
lang: en-US
aside: true
layout: doc
---

# Naive Implementation

---

This is just your quintessential implementation of CORS in .NET Core.

```cs
var builder = WebApplication.CreateBuilder(args);

...

// 1️⃣  Register CORS // [!code focus]
builder.Services.AddCors(options => // [!code focus]
{
    options.AddPolicy("BasicCors", policy =>// [!code focus]
    {
        policy.WithOrigins("https://your-frontend.com")// [!code focus]

              .WithMethods("GET", "POST", "DELETE", "OPTIONS")// [!code focus]

              .WithHeaders("Content-Type", "Access-Control-Allow-Origin")// [!code focus]

    });// [!code focus]
}); // [!code focus]


var app = builder.Build();

// 2️⃣  Enable CORS middleware (must appear BEFORE any endpoints/controllers) // [!code focus]
app.UseCors("BasicCors"); // [!code focus]

...

app.Run();
```
