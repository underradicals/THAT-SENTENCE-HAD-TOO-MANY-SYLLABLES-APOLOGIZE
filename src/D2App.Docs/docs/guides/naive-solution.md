---
title: Naive Implementation
lang: en-US
aside: true
layout: doc
---

# Naive Implementation

---

This is just your quintessential implementation of CORS in .NET Core. `AddCors` is an extension method on the `IServiceCollection` and excepts a generic delegate of type `Action<CorsOptions>`.

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

## Least Privilege and Integrity of Control Flow.

Now it is possible to include a configuration in your external configuration, that is external to your Infrastructure as Code (IaC).

The CorsOptions class contains a collection of named policies (`Dictionary<string, CorsPolicy>`), but unfortunately, there's no automatic support for loading complex CorsPolicy objects from JSON.
You'd need to build that mapping yourself. And then programmatically include it in you system:

```json
{
  "Cors": {
    "Policies": {
      "BasicCors": {
        "Origins": ["https://example.com"],
        "Methods": ["GET", "POST"],
        "Headers": ["Content-Type"]
      }
    }
  }
}
```

<br />

> ### Infrastructure Configuration should be hard to change and it should change rarely.

<br />

```cs
builder.Services.Configure<CorsOptions>(options =>
{
    var config = builder.Configuration.GetSection("Cors:Policies:BasicCors");
    var policy = new CorsPolicyBuilder()
        .WithOrigins(config.GetSection("Origins").Get<string[]>())
        .WithMethods(config.GetSection("Methods").Get<string[]>())
        .WithHeaders(config.GetSection("Headers").Get<string[]>())
        .Build();

    options.AddPolicy("BasicCors", policy);
});

```

However, let me warn you against this, as it violates `Least Privilege` and `Integrity of Control Flow`. CORS is by design a gatekeeper protecting your origin from malicious code. Making it easy for others to change and puts you site at risk. Infrastructure Configuration should be hard to change and it should change rarely. If you insist on keeping your configuration external to your IaC, then keep it behind an HSM (Hardware Security Module). This is a physical computing device designed to secure and manage cryptographic keys, the most critical element in protecting data, including data stored on disk.

### :key: HSM Key Management:

HSMs are specifically designed for the secure generation, storage, and management of cryptographic keys. These keys are crucial for encrypting and decrypting data on disk.
Key Protection: Unlike software-based encryption where keys might be stored on the same server as the data, making them vulnerable to software attacks, HSMs isolate the keys within a tamper-resistant, physically secure environment. This separation prevents attackers from accessing the keys, even if they gain access to the disk itself.

### :bank: Secure Operations:

HSMs perform cryptographic operations like encryption and decryption within their secure boundaries, never exposing the keys to the external system. This reduces the attack surface and significantly strengthens the security posture.

### :eyes: Transparent Data Encryption (TDE):

HSMs can be used to manage the keys for TDE solutions applied to databases and storage devices like disks. TDE encrypts data at rest, making it unreadable without the encryption key. By storing the key in the HSM, the security of the encrypted data is significantly enhanced.

### :wrench: Tamper Resistance:

HSMs are built with tamper-resistant or tamper-evident features. Tampering with the device can make it inoperable or trigger alerts, providing a layer of physical security.

### :scroll: Certification:

Many HSMs are certified to international standards like FIPS 140. This certification provides independent assurance of the device's security design and implementation, including its ability to protect keys and perform cryptographic functions securely.
