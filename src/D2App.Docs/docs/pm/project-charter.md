---
title: Project Charter
lang: en-US
aside: true
---

# **Project Charter**

## **Project Name:** D2 Information System

## **Project Purpose**

The purpose of this project is to organize and normalize the data provided by the Destiny 2 Manifest. In doing so, it will make the data more accessible and analyzable by transforming it into a structured PostgreSQL format. Additionally, the project will provide metrics and data-driven insights, along with publicly available RESTful API endpoints to support frontend application development.

---

## **Measurable Project Objectives**

- Ingest Destiny 2 Manifest data regularly.
- Extract and transform data from the Manifest’s SQLite format.
- Normalize and store the data in a PostgreSQL database.
- Expose public RESTful API endpoints for data access by frontend clients.
- Provide private RESTful API endpoints for secure data updates and admin access.
- Generate and expose key metrics and analytics derived from the normalized data.

---

## **High-Level Requirements**

- Automated data ingestion and transformation pipeline.
- Data storage in a scalable, normalized PostgreSQL schema.
- RESTful API built using a modern web framework (e.g., .NET, Node.js, or FastAPI).
- API authentication and authorization using OAuth 2.1 or similar.
- Frontend consumers must be able to access the public API with minimal setup.
- Monitoring and logging of ingestion, transformation, and API access.

---

## **High-Level Project Description, Boundaries, and Key Deliverables**

### **Description:**

D2App is a backend-focused system that transforms Destiny 2 Manifest data into a normalized format suitable for querying, analysis, and frontend consumption. It acts as an abstraction layer between Bungie’s manifest and downstream applications.

### **Boundaries:**

- The project will not include building a full-featured frontend application.
- Analysis will be limited to metrics derived from Manifest data (no gameplay telemetry).
- Only the most recent Manifest version will be ingested; historical comparison is out of scope.

### **Key Deliverables:**

- ETL pipeline for ingesting and transforming the Manifest.
- PostgreSQL database with normalized schema.
- RESTful public and private API endpoints.
- Documentation for API usage.
- Dashboard or metrics endpoint (optional, if time permits).

---

## **Assumptions and Constraints**

### **Assumptions:**

- Bungie.net API and Manifest will remain publicly accessible during development.
- The data structure of the Manifest remains relatively stable.
- PostgreSQL will meet storage and performance needs for this scope.

### **Constraints:**

- Limited to publicly available Manifest data (no private player data).
- Development time and resources are limited to a semester timeline.
- Budgetary constraints limit infrastructure to local or low-cost cloud options.

---

## **Overall Project Risk**

### **Moderate Risk.**

Key risks include:

- Unexpected changes to Bungie’s Manifest structure or API.
- Complexity of normalizing loosely structured game data.
- Managing rate limits or access restrictions from Bungie’s servers.

Risk mitigation includes:

- Early design for schema flexibility.
- Implementing logging and retry mechanisms.
- Designing the pipeline to be modular and testable.

---

### **Summary Milestone Schedule**

| Milestone                           | Estimated Date |
| ----------------------------------- | -------------- |
| Project Planning & Design           | Week 1–2       |
| Initial ETL Pipeline Implementation | Week 3–4       |
| API Design and Development          | Week 5–6       |
| Testing & Metrics Integration       | Week 7–8       |
| Documentation & Finalization        | Week 9–10      |
| Project Presentation                | Week 11        |

---

### **Preapproved Financial Resources**

None. Project will be developed using open-source tools and hosted on free-tier or local infrastructure as available.

---

### **Key Stakeholder List**

| Stakeholder         | Role/Interest                                 |
| ------------------- | --------------------------------------------- |
| Project Developer   | Designs and builds the system                 |
| Frontend Developers | Use the public API for UI features            |
| Bungie API Users    | Interested in normalized, accessible data     |
| Academic Advisor    | Oversees the project from a course standpoint |

---

### **Project Approval Requirements**

- All core components (ETL pipeline, database, and API) must be functional and documented.
- API endpoints must return accurate, validated data.
- System must demonstrate the ability to ingest and update from the Manifest at least once.
- Milestones must be met on time or with justified schedule adjustments.

---

### **Project Exit Criteria**

- The PostgreSQL database is populated with normalized data from the latest Destiny 2 Manifest.
- Public API endpoints are functioning and return valid responses.
- Documentation is complete and supports project continuity.
- System has been tested with at least one successful end-to-end data ingestion cycle.

---

### **Project Team**

- **Joseph Shaw** – Full-stack Developer, Project Lead
  Responsible for architecture, development, deployment, and documentation.

---

### **Changelog**

| Date       | Author | Notes       |
| ---------- | ------ | ----------- |
| 06/26/2025 | Joseph | First Entry |
