---
title: Getting Started
lang: en-US
aside: true
layout: doc
---

# 🚀 Getting Started

---

Welcome to the **Guides** section of the D2App documentation. This area provides clear, step-by-step instructions and real-world walkthroughs to help you confidently work within the D2App ecosystem. Whether you're a developer, contributor, or stakeholder, these guides are crafted to assist you in navigating key workflows, implementing features, and integrating components smoothly.

---

### 🧰 Project Setup & Local Development

Get your development environment up and running quickly and reliably.

**What's included:**

- Tooling prerequisites (e.g., .NET SDK, Node.js)
- Cloning and restoring the project
- Environment variable setup
- Running development servers
- Initial health checks and validation

::: tip ⛔
This guide does _not_ cover CI/CD, production deployment, or infrastructure automation. See [Deployment and environment configuration](#-deployment-and-environment-configuration) for those details.
:::

---

### 🔐 Authentication & Authorization Flows

Understand how user access is managed throughout the platform using modern identity protocols.

**What's included:**

- OAuth 2.1 with PKCE
- Cookie and JWT token handling
- Login/session management
- Role-based access control (RBAC)
- Integration with the internal Authorization Server

::: tip ⚠️
This section focuses on D2App’s implementation. It does not explore deep OAuth theory or third-party provider configurations.
:::

---

### 🔗 API Usage & Integration Patterns

Leverage and extend the D2App Web API effectively using standardized integration patterns.

**What's included:**

- REST endpoint usage
- Request/response shaping
- DTO conventions and error handling
- Guidelines for extending controllers and services

::: tip 🔍
Database design and ORM behavior are outside the scope of this section. Refer to architectural documents for those concerns.
:::

---

### 🔄 Frontend ↔ Backend Communication

Ensure smooth and secure data flow between the client and the server layers.

**What's included:**

- API call conventions from the frontend
- Token management and secure storage
- Abstraction strategies (e.g., Axios wrappers, React Query)
- HTTP interaction best practices

::: tip 🧠
This guide does not delve into frontend state management or backend storage logic.
:::

---

### 🚢 Deployment & Environment Configuration

Prepare and configure your application for consistent behavior across environments.

**What's included:**

- Environment variable management
- Docker and build processes
- Dev/staging/production setup guidelines
- Hosting and deployment practices

::: tip 🔧
This section excludes CI/CD pipelines and infrastructure provisioning. See the DevOps documentation for those areas.
:::

---

### 🛠️ Troubleshooting Common Issues

Quick solutions to frequent development and integration blockers.

**What's included:**

- Dependency and setup errors
- Misconfigurations
- Cross-platform quirks
- Reproducible bug resolution patterns

::: tip 📌
This is not a comprehensive issue tracker or support desk. Focus is on development-phase issues.
:::
