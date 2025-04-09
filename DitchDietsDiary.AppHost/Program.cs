var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.DitchDietsDiary>("ditchdietsdiary");

builder.Build().Run();
