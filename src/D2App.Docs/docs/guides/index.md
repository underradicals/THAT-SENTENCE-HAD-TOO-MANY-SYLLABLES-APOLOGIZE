---
title: Why Deliverables
lang: en-US
aside: true
layout: doc
---

# Patterns and Guides: Definition, Purpose, and Usage

### 🔹 What are **Patterns**?

**Software patterns** are **general, reusable solutions** to common problems or scenarios encountered in software design and development. They are **not code**, but high-level **strategies and templates** that inform architecture, behavior, or implementation practices.

#### ✳️ Purpose:

- Promote **consistency** and **best practices** across codebases.
- Reduce cognitive load by offering **proven solutions** to recurring problems.
- Improve **maintainability**, **readability**, and **scalability** of software systems.
- Enable **cross-team alignment** on how certain problems are approached and solved.

#### 🛠️ How Developers Use Patterns:

- Reference when implementing complex modules (e.g., using a repository pattern for data access).
- Adopt for solving design problems (e.g., deciding between event-driven or request-driven architecture).
- Avoid anti-patterns by learning what **not to do**.

#### 🗂️ Examples:

- **Design Patterns**: Singleton, Strategy, Factory, Observer.
- **Architectural Patterns**: MVC, Microservices, CQRS, Event Sourcing.
- **Security Patterns**: OAuth2 flows, CSRF prevention, data sanitization.

#### 📊 How Project Managers Use Patterns:

- Ensure engineering teams follow **organization-approved practices**.
- Evaluate technical design decisions for **alignment and risk**.
- Identify **resource requirements** and complexity based on pattern choices (e.g., CQRS implies additional infra and expertise).
- Aid in creating **technical governance** and **coding standards**.

---

### 🔹 What are **Guides**?

**Guides** are **step-by-step instructions or process walkthroughs** that help someone perform a specific task, achieve a defined outcome, or understand a particular system workflow.

#### ✳️ Purpose:

- Enable **onboarding**, **support**, and **knowledge transfer**.
- Document **how-to** procedures, internal conventions, and usage workflows.
- Minimize tribal knowledge by formalizing processes.
- Bridge the gap between **conceptual design** and **practical implementation**.

#### 🛠️ How Developers Use Guides:

- Follow setup and integration instructions (e.g., "How to connect a new client app").
- Reference examples to implement features (e.g., "How to add a protected API endpoint").
- Use to debug and resolve issues (e.g., "Troubleshooting JWT auth failures").

#### 📊 How Project Managers Use Guides:

- Track **progress of onboarding** and developer readiness.
- Identify **documentation gaps** that cause inefficiencies or repeat questions.
- Include as deliverables in **project timelines** or **milestone reviews**.
- Assess team alignment with **expected workflows** and standards.

---

## 🔄 How They Work Together

| Aspect        | Patterns                           | Guides                            |
| ------------- | ---------------------------------- | --------------------------------- |
| Nature        | Abstract, strategic                | Procedural, instructional         |
| Purpose       | Solve recurring problems elegantly | Enable consistent execution       |
| Audience      | Architects, senior developers      | All developers, testers, support  |
| Format        | Narrative with examples/diagrams   | Step-by-step, often code-oriented |
| Reusability   | High — applies across projects     | Moderate — specific to context    |
| Maintained By | Tech leads, architects             | Dev leads, tech writers           |

---

### 📈 Value in Real-World Projects

- **For onboarding**: New team members ramp up faster by reading both _patterns_ (why things are structured a certain way) and _guides_ (how to get things running).
- **For cross-team collaboration**: Reduces friction by aligning on **vocabulary**, **architecture**, and **expectations**.
- **For long-term scalability**: Encourages the growth of a **knowledge base** that can be referenced even as teams or tools change.

---
