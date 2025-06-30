---
title: What are health checks
lang: en-US
aside: true
layout: doc
---

# What are health checks

---

## ✅ Health Checks in .NET Core Web APIs

### 📌 What Are Health Checks?

Health checks are diagnostic endpoints exposed by an application to report on its **runtime health** and **readiness**. In .NET Core, health checks are implemented using the built-in `Microsoft.AspNetCore.Diagnostics.HealthChecks` middleware, which provides a structured way to assess the application's operational state.

---

### 🧠 What Do They Do?

Health checks serve three primary purposes:

1. **Application Liveness**
   Confirms the app is running and able to respond to requests (i.e., it hasn't crashed or deadlocked).

2. **Dependency Health Monitoring**
   Evaluates whether critical services (e.g., databases, queues, caches, APIs) are reachable and responsive.

3. **Readiness Indicators**
   Signals whether the app is ready to serve traffic—useful during startup, deployments, or autoscaling events.

Each registered check reports its status (`Healthy`, `Degraded`, or `Unhealthy`) and optional diagnostic details. These results are aggregated into a structured HTTP response.

---

### ⚙️ Why Are They Used?

Health checks are used by **platforms**, **orchestrators**, and **DevOps pipelines** to:

| Use Case                      | Description                                                                      |
| ----------------------------- | -------------------------------------------------------------------------------- |
| **Load balancers / Proxies**  | Route traffic only to healthy nodes                                              |
| **Kubernetes**                | `livenessProbe` and `readinessProbe` check application health and startup status |
| **CI/CD Pipelines**           | Gate deployments or rollbacks based on runtime status                            |
| **Monitoring Systems**        | Enable uptime monitoring and incident response                                   |
| **Zero-downtime Deployments** | Only mark instances as ready once they pass internal checks                      |

---

### 🚫 Why They’re Not Trivial

Although adding a simple `/health` endpoint appears easy, production-grade health checks are **non-trivial** due to:

- The need to coordinate multiple dependency checks (databases, external services, etc.)
- The necessity to distinguish between **liveness** (is the process alive) and **readiness** (can it actually serve traffic)
- Handling transient failures gracefully to avoid false positives/negatives
- Ensuring health checks themselves don't overload fragile dependencies (e.g., polling a database too often)

Designing a robust health check strategy requires thoughtful consideration of system behavior during startup, failure, and recovery scenarios.

---

### ✅ .NET Core Integration Summary

- Health checks are added via `services.AddHealthChecks()` in DI.
- Dependencies can be monitored via `.AddSqlServer(...)`, `.AddRedis(...)`, etc.
- The results are exposed on an endpoint, e.g., `/health`, using `app.MapHealthChecks(...)`.
- Custom response formatting can be used to emit structured JSON for monitoring systems.

---

Let me know if you want this turned into Markdown, an OpenAPI description, or part of a README/documentation site.
